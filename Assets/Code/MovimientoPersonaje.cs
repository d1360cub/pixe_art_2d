using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour
{
    public float velocidadMovimiento = 5f;
    public float fuerzaSalto = 7f;
    private bool enElsuelo = false;

    private Rigidbody2D cuerpoRigido;
    private Animator animaciones;

    void Awake()
    {
        cuerpoRigido = GetComponent<Rigidbody2D>();
        animaciones = GetComponent<Animator>();
    }

    void Update()
    {
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        cuerpoRigido.velocity = new Vector2(movimientoHorizontal * velocidadMovimiento, cuerpoRigido.velocity.y);

        if (Input.GetButtonDown("Jump") && enElsuelo)
        {
            cuerpoRigido.AddForce(new Vector2(0f, fuerzaSalto), ForceMode2D.Impulse);
            enElsuelo = false;
        }
        animaciones.SetFloat("HorizontalMovement", Mathf.Abs(movimientoHorizontal));
    }

    void OnCollisionEnter2D (Collision2D collision)
    {
        enElsuelo = collision.gameObject.CompareTag("Suelo");  
    }

}