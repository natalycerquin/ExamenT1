using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNinja : MonoBehaviour
{
    float speed = 0.1f;
    public float jumpSpeed = 1600.0f;
    int salto = 2;
    int estado = 0;

    ///Mover Personaje
    Rigidbody2D rb;
    RigidbodyConstraints2D congelar;
    ///Animacion
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Transform transform = GetComponent<Transform>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetInteger("Estado", estado);
        speed = 7.0f;
        rb.velocity = new Vector2(speed, rb.velocity.y);

        if (salto <= 1)
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                animator.SetInteger("Estado", 1);
                rb.AddForce(Vector2.up * jumpSpeed);
                salto++;
                jumpSpeed = 800.0f;
            }

        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Suelo")
        {
            salto = 0;
            jumpSpeed = 1600.0f;
            estado = 0;
        }
        if (collision.gameObject.tag == "Zombie")
        {
           
            speed = 0f;
            estado = 2;
            animator.SetInteger("Estado", estado);
            Destroy(this.gameObject, 1);
        }
    }
}
