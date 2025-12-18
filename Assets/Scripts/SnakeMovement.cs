using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    private int vidas;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        vidas = 1;
    }

    void Update()
    {
        if (player == null) return;
        Movimiento();
        Direccion();
    }
    public void Hit()
    {
        vidas--;
        if (vidas < 0) Destroy(gameObject);
    }
    private void Movimiento()
    {
        float distance = Mathf.Abs(player.transform.position.x - transform.position.x);
        if (distance < 1f)
            rb.velocity = new Vector3(0.2f * transform.localScale.x, 0, 0);
        else
            rb.velocity = Vector3.zero;
    }
    private void Direccion()
    {
        Vector3 direction = player.transform.position - transform.position;
        if (direction.x >= 0.0f) transform.localScale = new Vector3(1, 1, 1);
        else transform.localScale = new Vector3(-1, 1, 1);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        MovimientoRey rey = collision.collider.GetComponent<MovimientoRey>();
        if (rey != null) 
            rey.Hit();
    }
}
