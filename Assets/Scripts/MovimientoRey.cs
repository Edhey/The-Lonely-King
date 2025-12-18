using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MovimientoRey : MonoBehaviour
{
    [SerializeField]
    private GameObject menu_gameover;
    [SerializeField]
    private GameObject boton_reanudar;
    private Rigidbody2D rb;
    private Animator animator;
    public GameObject fire_ball_prefab;
    public GameObject melee_hit_prefab;
    private CapsuleCollider2D capsule_collider;
    public GameObject[] vidas_UI;

    public float speed;
    public float jump_force;
    public float fire_shoot_cooldown;
    public float hit_cooldown;
    public float fire_shoot_timer;
    public float hit_timer;
    public float velocidad_escalar;

    public TextMeshProUGUI FireBallCooldown;
    public TextMeshProUGUI HitCooldown;
    public TextMeshProUGUI GameOverText;

    private bool first_fire_shoot = true;
    private bool first_melee_hit = true;
    private bool ground;
    private bool escalando;
    public bool fire_shoot = false;

    private float vertical;
    private float horizontal;
    private float last_shoot_time;
    private float last_hit_time;
    private float gravedad_inicial;
    private int vidas;
    void Start()
    {
        menu_gameover.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        gravedad_inicial = rb.gravityScale;
        capsule_collider = GetComponent<CapsuleCollider2D>();
        vidas = vidas_UI.Length - 1;
        for (int i = 0; i < vidas_UI.Length; i++)
        {
            vidas_UI[i].SetActive(true);
        }
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            fire_shoot = true;
        }
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        animator.SetBool("Running", horizontal != 0.0f);
        if (Mathf.Abs(rb.velocity.y) > Mathf.Epsilon)
        {
            animator.SetFloat("VelocidadY", Mathf.Sign(rb.velocity.y));
        } else
        {
            animator.SetFloat("VelocidadY", 0);
        }
        animator.SetFloat("VelocidadX", horizontal);
        Debug.DrawRay(transform.position, Vector3.down * 0.12f, Color.red);
        if (Physics2D.Raycast(transform.position, Vector3.down, 0.12f)) {
            //Debug.Log("Suelo");
            ground = true;
        } else { 
            //Debug.Log("Aire");
            ground = false;
        }
        if (Input.GetKeyUp(KeyCode.Escape)) {
            GameOverText.text = "PAUSA";
            boton_reanudar.SetActive(true);
            menu_gameover.SetActive(true);
            Time.timeScale = 0f;
        }
        if (Input.GetKeyDown(KeyCode.W) && ground || Input.GetKeyDown(KeyCode.Space) && ground 
            || Input.GetKeyDown(KeyCode.UpArrow) && ground) {
            Jump();
        }
        if (Input.GetKeyDown(KeyCode.E) && Time.time > last_shoot_time + fire_shoot_cooldown && fire_shoot
            || Input.GetKeyDown(KeyCode.E) && first_fire_shoot && fire_shoot) {
            first_fire_shoot = false;
            FireShoot();
            last_shoot_time = Time.time;
        }
        if (Input.GetKeyDown(KeyCode.Q) && Time.time > last_hit_time + hit_cooldown 
            || Input.GetKeyDown(KeyCode.Q) && first_melee_hit)
        {
            first_melee_hit = false;
            MeleeHit();
            last_hit_time = Time.time;
        }
        if (horizontal < 0.0f) transform.localScale = new Vector3(-1, 1, 1);
        else if (horizontal > 0.0f) transform.localScale = new Vector3(1, 1, 1);
        Escalar();
        FireShootTimer();
        HitTimer();
        Puerta();
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal, rb.velocity.y);
    }
    private void Jump()
    {
        // Debug.Log("Salto");
        rb.AddForce(Vector2.up * jump_force);
    }

    private void FireShoot() {
        animator.SetBool("Hit", true);
        fire_shoot_timer = fire_shoot_cooldown;
        Vector3 direction;
        if (transform.localScale.x == 1.0f) direction = Vector2.right;
        else direction = Vector2.left;
        GameObject fire_ball = Instantiate(fire_ball_prefab, transform.position + direction * 0.1f, Quaternion.identity);
        fire_ball.GetComponent<FireShootScript>().SetDirection(direction);
    }

    private void FireShootTimer()
    {
        if (fire_shoot_timer >= 0.5f)
        {
            fire_shoot_timer -= Time.deltaTime;
            FireBallCooldown.text = fire_shoot_timer.ToString("f0");
        } else
        {
            FireBallCooldown.text = "";
        }
    }
    private void MeleeHit() {
        animator.SetBool("Hit", true);
        hit_timer = hit_cooldown;
        Vector3 direction;
        if (transform.localScale.x == 1.0f) direction = Vector2.right;
        else direction = Vector2.left;
        GameObject melee_hit = Instantiate(melee_hit_prefab, transform.position + direction * 0.1f, Quaternion.identity);
        melee_hit.GetComponent<HitScript>().SetDirection(direction);
    }
    private void HitTimer()
    {
        if (hit_timer >= 0.5f)
        {
            hit_timer -= Time.deltaTime;
            HitCooldown.text = hit_timer.ToString("f0");
        }
        else
        {
            HitCooldown.text = "";
        }
    }
    private void Escalar()
    {
        if ((vertical != 0 || escalando) && (capsule_collider.IsTouchingLayers(LayerMask.GetMask("Escalera"))))
        {
            Vector2 velocidad_subida = new Vector2(rb.velocity.x, vertical * velocidad_escalar);
            rb.velocity = velocidad_subida;
            rb.gravityScale = 0;
            escalando = true;
        } else
        {
            rb.gravityScale = gravedad_inicial;
            escalando = false;
        }
        if (ground)
        {
            escalando = false;
        }
        animator.SetBool("Escalar", escalando);
    }
    public void Hit()
    {
        vidas_UI[vidas].SetActive(false);
        vidas--;
        if (vidas < 0)
        {
            boton_reanudar.SetActive(false);
            menu_gameover.SetActive(true);
            GameOverText.text = "¡HAS PERDIDO!";
            Destroy(gameObject);
        }
    }
    private void Puerta()
    {
        if (capsule_collider.IsTouchingLayers(LayerMask.GetMask("Puerta")) && Input.GetKeyDown(KeyCode.Return)) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
