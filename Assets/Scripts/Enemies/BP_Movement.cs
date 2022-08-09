using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BP_Movement : Enemy_Movement
{
    [SerializeField] Game_Manager gm;
    [SerializeField] Transform player_pos;
    public GameObject fire;
    private Rigidbody2D rb;
    const int BLUE_INDEX = 1;
    [SerializeField] int move_counter;
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
        gm.enemies[BLUE_INDEX].Add(gameObject);
        lookDirection = new Vector2(-1 + 2 * Random.Range(0, 2), 0);
    }

    private void Update()
    {
        if (currentHealth <= 0)
        {
            gm.enemies[BLUE_INDEX].Remove(gameObject);
            Destroy(gameObject);
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
            Vector2 position = rb.position;
            int move = move_counter / 2;
            if (move % 2 == 0)
            {
                if (move / 2 < 3)
                {
                    RaycastHit2D ray = Physics2D.Raycast(position + Vector2.right * 0.7f, Vector2.right, .25f, mask);
                    if (ray.collider == null)
                    {
                        position += Vector2.right;
                        lookDirection = Vector2.right;
                        move_counter++;
                    }
                }
                else
                {
                    RaycastHit2D ray = Physics2D.Raycast(position + Vector2.left * 0.7f, Vector2.left, .25f, mask);
                    if (ray.collider == null)
                    {
                        position += Vector2.left;
                        lookDirection = Vector2.left;
                        move_counter++;
                    }
                }
            }
            else
            {
                if ((move - 1) / 2 < 4 && (move - 1) / 2 > 0)
                {
                    RaycastHit2D ray = Physics2D.Raycast(position + Vector2.down * 0.7f, Vector2.down, .25f, mask);
                    if (ray.collider == null)
                    {
                        position += Vector2.down;
                        lookDirection = Vector2.down;
                        move_counter++;
                    }
                }
                else
                {
                    RaycastHit2D ray = Physics2D.Raycast(position + Vector2.up * 0.7f, Vector2.up, .25f, mask);
                    if (ray.collider == null)
                    {
                        position += Vector2.up;
                        lookDirection = Vector2.up;
                        move_counter++;
                    }
                }
            }

            if (move_counter == 24)
            {
                move_counter = 0;
            }
            rb.MovePosition(position);
            yield return new WaitForFixedUpdate();
            GameObject newFire = Instantiate(fire, transform.position + (Vector3)(lookDirection * -1), Quaternion.identity);
            Fire_Collision fc = newFire.GetComponent<Fire_Collision>();
            fc.gm = gm;
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
