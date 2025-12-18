using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public void CambioEscena(string escena)
    {
        SceneManager.LoadScene(escena);
    }
}
