using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSalto2 : MonoBehaviour
{
    Rigidbody2D rb;
    public float jumpSpeed = 1600.0f;
    public float velocityX = 5f;
    bool Salto2 = true;
    SpriteRenderer direcion;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        direcion = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Salto2)
        {
            Salto2 = false;
            rb.AddForce(Vector2.up * jumpSpeed);
            rb.velocity = new Vector2(velocityX, rb.velocity.y);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Suelo")
        {
            velocityX = velocityX * -1;
            Salto2 = true;
            direcion.flipX = !direcion.flipX;
        }
    }
}
