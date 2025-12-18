using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class MalvadoScript : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    private int vidas;
    private Rigidbody2D rb;
    [SerializeField]
    private GameObject menu;
    [SerializeField]
    private GameObject fire_ball_prefab;
    public TextMeshProUGUI WinText;

    public float fire_shoot_cooldown;
    public float last_shoot_time;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        vidas = 5;
        last_shoot_time = Time.time;
    }

    void Update()
    {
        if (player == null) return;
        Movimiento();
        Direccion();
        FireShoot();
    }
    public void Hit()
    {
        vidas--;
        if (vidas < 0)
        {
            WinText.text = "¡Felicidades, has ganado!";
            menu.SetActive(true);
            Destroy(gameObject);
        }
    }
    private void Movimiento()
    {
        float distance = Mathf.Abs(player.transform.position.x - transform.position.x);
        if (distance < 2.5f)
            rb.velocity = new Vector3(0.5f * transform.localScale.x, 0, 0);
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
    private void FireShoot()
    {
        float distance = Mathf.Abs(player.transform.position.x - transform.position.x);
        if (distance < 1f && Time.time > last_shoot_time + fire_shoot_cooldown)
        {
            last_shoot_time = Time.time;
            Vector3 direction;
            if (transform.localScale.x == 1.0f) direction = Vector2.right;
            else direction = Vector2.left;
            GameObject fire_ball = Instantiate(fire_ball_prefab, transform.position + direction * 0.1f, Quaternion.identity);
            fire_ball.GetComponent<FireShootScript>().SetDirection(direction);
        }
    }
}
