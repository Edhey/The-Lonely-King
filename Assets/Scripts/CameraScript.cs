using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject main_character;
    void Update()
    {
        if (main_character == null) return;
        Vector3 position = transform.position;
        position.x = main_character.transform.position.x + 1.5f;
        transform.position = position;
    }
}
