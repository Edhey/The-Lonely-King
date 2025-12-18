using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundMove : MonoBehaviour
{
    private Rigidbody2D rb_jugador;
    private void Start()
    {
        rb_jugador = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();

    }
    void Update()
    {
        if (rb_jugador == null) return;
        transform.position = new Vector3(rb_jugador.position.x + 1.4f, -2f);
    }
}
