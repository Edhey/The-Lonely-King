using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CofreScript : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    public GameObject informacion;
    public GameObject FireBallImage;
    private Animator animator;
    private bool cofre_habilitado;
    public LayerMask personaje;
    private void Start()
    {
        FireBallImage.SetActive(false);
        informacion.SetActive(false);
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        cofre_habilitado = Physics2D.OverlapCircle(transform.position, 0.2f, personaje);
        if (cofre_habilitado && Input.GetKeyDown(KeyCode.Return)) { 
            animator.SetBool("Abierto", true);
            player.GetComponent<MovimientoRey>().fire_shoot = true;
            informacion.SetActive(true);
            FireBallImage.SetActive(true);
        }
    }
}
