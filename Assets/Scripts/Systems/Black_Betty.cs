using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Black_Betty : Enemy_Movement
{
    [SerializeField] Game_Manager gm;
    private int counter;
    private Rigidbody2D rb;

    private void Start()
    {
        gm.enemies[7].Add(gameObject);
        counter = 0;
        rb = GetComponent<Rigidbody2D>();
    }

    public override IEnumerator Move()
    {
        counter++;
        if(counter == 3)
        {
            yield return new WaitForFixedUpdate();
            Vector2 position = rb.position;
            position += Vector2.left;
            rb.MovePosition(position);
            counter = 0;
        }
        yield return new WaitForSeconds(0f);
    }

    public override void Stun()
    {

    }

    public override void TakeDamage(int dmg)
    {

    }
}
