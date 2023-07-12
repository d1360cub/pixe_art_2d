using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguirPersonaje : MonoBehaviour
{
    public Transform jugador;
    public float separacion = 2f;

    void Update()
    {
        transform.position = new Vector3(jugador.position.x + separacion, transform.position.y, transform.position.z);
    }
}
