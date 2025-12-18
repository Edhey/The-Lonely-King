using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGameOver : MonoBehaviour
{
    [SerializeField]
    private GameObject boton_reanudar;
    public void Reiniciar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;
    }

    public void MenuPrincipal(string menu)
    {
        SceneManager.LoadScene(menu);
        Time.timeScale = 1.0f;
    }
    public void Salir()
    {
        Application.Quit();
    }
    public void Reanudar()
    {
        gameObject.SetActive(false);
        boton_reanudar.SetActive(false);
        Time.timeScale = 1.0f;
    }
    public void Creditos()
    {
        SceneManager.LoadScene(4);
        Time.timeScale = 1.0f;
    }
}
