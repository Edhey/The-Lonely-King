using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireShootScript : MonoBehaviour
{
    Animator player_animator;
    private Rigidbody2D rb;
    
    private Vector2 direction;
    public float speed;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player_animator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        rb.velocity = direction * speed;
    }

    public void SetDirection(Vector2 true_direction)
    {
        direction = true_direction;
    }
    public void DestroyFireShoot()
    {
        player_animator.SetBool("Hit", false);
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        MalvadoScript malvado = collision.GetComponent<MalvadoScript>();
        MovimientoRey rey = collision.GetComponent<MovimientoRey>();
        SnakeMovement snake = collision.GetComponent<SnakeMovement>();
        if (malvado != null)
        {
            malvado.Hit();
        }
        if (snake != null)
        {
            snake.Hit();
        }
        if (rey != null)
        {
            rey.Hit();
        }
        DestroyFireShoot();
    }
}
