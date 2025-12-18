using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaidaScript : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {
            MovimientoRey rey = collision.GetComponent<MovimientoRey>();
            if (rey != null) rey.Hit();
            player.transform.position = new Vector3(-2.8f, -0.2f, 0);
        }      
    }
}
