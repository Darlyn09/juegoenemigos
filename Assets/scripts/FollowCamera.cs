using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FollowCamera : MonoBehaviour
{
    public Transform target;         // Jugador
    public Vector3 offset = new Vector3(0f, 3f, -6f); // Posición relativa
    public float smoothSpeed = 0.125f;                // Suavidad

    void LateUpdate()
    {
        if (target == null) return;

        // 🔄 Calcula el offset relativo a la rotación del jugador
        Vector3 rotatedOffset = target.rotation * offset;
        Vector3 desiredPosition = target.position + rotatedOffset;

        // Suaviza el movimiento
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        // Mira al jugador (ajustable)
        transform.LookAt(target.position + Vector3.up * 2f); // Mira al torso, no los pies
    }
}
