using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VI_Stun : MonoBehaviour
{
    private Rigidbody2D rb;
    public Vector2 lookDirection;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 position = rb.position;
        position += lookDirection * speed;
        rb.MovePosition(position);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Enemy_Movement em = collision.gameObject.GetComponent<Enemy_Movement>();
        if (collision.collider.tag == "Tilemap")
        {
            Destroy(gameObject);
        }
        else if (em != null)
        {
            em.Stun();
            Destroy(gameObject);
        }
    }
}
