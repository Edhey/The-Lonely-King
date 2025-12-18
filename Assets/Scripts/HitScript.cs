using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitScript : MonoBehaviour
{
    Animator player_animator;
    private void Start()
    {
        player_animator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
    }
    public void SetDirection(Vector2 true_direction)
    {
        transform.localScale = new Vector2(true_direction.x, 1);
    }

    public void DestroyHit()
    {
        if (player_animator != null)
        {
            player_animator.SetBool("Hit", false);
        }
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        MalvadoScript malvado = collision.GetComponent<MalvadoScript>();
        SnakeMovement snake = collision.GetComponent<SnakeMovement>();
        if (snake != null)
        {
            snake.Hit();
        }
        if (malvado != null)
        {
            malvado.Hit();
        }
    }
}
