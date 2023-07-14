using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour
{
    public float velocidadMovimiento = 5f;
    public float fuerzaSalto = 7f;
    public Transform RestartPoint;

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

        if (movimientoHorizontal > 0)
            transform.localScale = new Vector3(1, 1, 1);
        else if (movimientoHorizontal < 0)
            transform.localScale = new Vector3(-1, 1, 1);

        animaciones.SetFloat("HorizontalMovement", Mathf.Abs(movimientoHorizontal));
    }

    void OnCollisionEnter2D (Collision2D collision)
    {
        enElsuelo = collision.gameObject.CompareTag("Suelo");
        if(collision.gameObject.CompareTag("Death"))
            Restart();
    }

    void Restart()
    {
        cuerpoRigido.velocity = Vector2.zero;
        cuerpoRigido.angularVelocity = 0;
        cuerpoRigido.bodyType = RigidbodyType2D.Static;
        transform.position = RestartPoint.position;
        cuerpoRigido.bodyType = RigidbodyType2D.Dynamic;
    }
}