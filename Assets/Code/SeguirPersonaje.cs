using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguirPersonaje : MonoBehaviour
{
    public Transform jugador;
    public float distanciaX = 1f;
    public float distanciaY = 1f;

    void Update()
    {
        transform.position = new Vector3(jugador.position.x + distanciaX, jugador.position.y + distanciaY, transform.position.z);
    }
}
