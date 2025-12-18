using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] vidas;

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
