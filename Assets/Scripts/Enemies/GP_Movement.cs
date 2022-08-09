using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GP_Movement : Enemy_Movement
{
    [SerializeField] Game_Manager gm;
    [SerializeField] Transform player_pos;
    private Rigidbody2D rb;
    const int GREEN_INDEX = 3;
    private bool canMove;
    private Vector2 lookDirection;
    private int currentHealth;
    private int maxHealth;
    private int stunCounter;

    void Start()
    {
        stunCounter = 0;
        maxHealth = 10;
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
        gm.enemies[GREEN_INDEX].Add(gameObject);
        canMove = true;
        lookDirection = new Vector2(-1 + 2 * Random.Range(0, 2), 0);
    }

    private void Update()
    {
        if (currentHealth <= 0)
        {
            gm.enemies[GREEN_INDEX].Remove(gameObject);
            Destroy(gameObject);
        }
        float pos_dif = player_pos.position.x - transform.position.x;
        if(pos_dif >= 0)
        {
            lookDirection = Vector2.right;
        }
        else
        {
            lookDirection = Vector2.left;
        }

        if (lookDirection == Vector2.right)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (lookDirection == Vector2.left)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    public override IEnumerator Move()
    {
        if (stunCounter <= 0)
        {
            LayerMask mask = 49344;
            if (canMove)
            {
                yield return new WaitForFixedUpdate();
                float pos_dif = player_pos.position.y - transform.position.y;
                if (pos_dif > 0.8)
                {
                    RaycastHit2D ray = Physics2D.Raycast(rb.position + Vector2.up * 0.6f, Vector2.up, .4f, mask);
                    if (ray.collider == null)
                    {
                        Vector2 position = rb.position;
                        position += Vector2.up;
                        rb.MovePosition(position);
                    }
                }
                else if (pos_dif < -0.8)
                {
                    RaycastHit2D ray = Physics2D.Raycast(rb.position + Vector2.down * 0.6f, Vector2.down, .4f, mask);
                    if (ray.collider == null)
                    {
                        Vector2 position = rb.position;
                        position += Vector2.down;
                        rb.MovePosition(position);
                    }
                }
            }
            canMove = !canMove;
            yield return new WaitForSeconds(0f);
        }
        stunCounter--;
    }

    override public void TakeDamage(int dmg)
    {
        currentHealth -= dmg;
    }

    public override void Stun()
    {
        stunCounter = 2;
    }
}
