using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_Movement : Enemy_Movement
{
    public Game_Manager gm;
    public Vector2 lookDirection;
    const int VIVIVI_COIN_INDEX = 5;
    private BoxCollider2D coinCollider;
    private Rigidbody2D rb;
    private int currentHealth;
    private int maxHealth;

    private void Start()
    {
        gm.enemies[VIVIVI_COIN_INDEX].Add(gameObject);
        coinCollider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    public override IEnumerator Move()
    {
        coinCollider.enabled = false;
        Vector2 position = rb.position;
        position += lookDirection;
        rb.MovePosition(position);
        //transform.position = position;
        yield return new WaitForFixedUpdate();
        coinCollider.enabled = true;
        yield return new WaitForFixedUpdate();
        coinCollider.enabled = false;
    }

    override public void TakeDamage(int dmg)
    {

    }

    public override void Stun()
    {
        throw new System.NotImplementedException();
    }
}
