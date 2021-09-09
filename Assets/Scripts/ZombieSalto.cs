using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSalto : MonoBehaviour
{
    Rigidbody2D rb;
    public float jumpSpeed = 100.0f;
    bool Salto = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Salto == false)
        {
            Salto = true;
            rb.AddForce(Vector2.up * jumpSpeed);
        }
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Suelo")
        {
            Salto = false;
        }
    }
}
