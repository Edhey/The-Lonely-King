using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditosScript : MonoBehaviour
{
    Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        rb.velocity = new Vector3(0, 6f, 0);
    }
}
