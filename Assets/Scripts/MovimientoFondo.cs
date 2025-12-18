using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoFondo : MonoBehaviour
{
    [SerializeField] private Vector2 velocidad_movimiento;
    private Vector2 offset;
    private Material material;
    private Rigidbody2D rb_jugador;
    private void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
        rb_jugador = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (rb_jugador == null) return;
        offset = (rb_jugador.velocity.x * 0.1f) * velocidad_movimiento * Time.deltaTime;
        material.mainTextureOffset += offset;
    }
}
