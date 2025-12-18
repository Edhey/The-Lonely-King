using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carteles : MonoBehaviour
{
    public GameObject informacion;
    // public GameObject mostrar_info;

    public bool info_habilitada;
    // public bool mostrar_info_habilitada;

    public LayerMask personaje;
    void Start()
    {
        informacion.gameObject.SetActive(false);
        // mostrar_info.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        info_habilitada = Physics2D.OverlapCircle(transform.position, 0.8f, personaje);
        if (info_habilitada) informacion.gameObject.SetActive(true);
        else informacion.gameObject.SetActive(false);
        /*
        mostrar_info_habilitada = Physics2D.OverlapCircle(transform.position, 1, personaje);
        if (mostrar_info_habilitada && Input.GetKeyDown(KeyCode.Return)) 
            mostrar_info.gameObject.SetActive(true);
        else mostrar_info.gameObject.SetActive(false);
        */
    }
}
