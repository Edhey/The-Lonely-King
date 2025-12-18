using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidasUI : MonoBehaviour
{
    public GameObject[] vidas;

    // private int numero_de_vidas = 3;
    void Start()
    {
            
    }
    void Update()
    {
        
    }
    public void EliminaVida(int indice)
    {
        vidas[indice].SetActive(false);
    }

    public void GanaVida(int indice)
    {
        vidas[indice].SetActive(true);
    }
}
