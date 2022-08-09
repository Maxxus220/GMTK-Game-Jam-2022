using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VIVIVI_Movement : Enemy_Movement
{
    [SerializeField] GameObject coinPrefab;
    [SerializeField] Game_Manager gm;
    [SerializeField] GameObject vi;
    private int canMove;
    [SerializeField] Vector2 lookDirection;
    const int RANGED_INDEX = 4;
    private int maxHealth;
    [SerializeField] int currentHealth;
    private int stunCounter;
    private Animator am;

    // Start is called before the first frame update
    void Start()
    {
        am = GetComponent<Animator>();
        stunCounter = 0;
        maxHealth = 15;
        currentHealth = maxHealth;
        canMove = 1;
        if (lookDirection == Vector2.right)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if(lookDirection == Vector2.left)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            if(Random.Range(0,2) == 1)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
            else
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
        }
        gm.enemies[RANGED_INDEX].Add(gameObject);
    }

    private void Update()
    {
        if(currentHealth <= 0)
        {
            gm.enemies[RANGED_INDEX].Remove(gameObject);
            Destroy(gameObject);
        }
    }

    public override IEnumerator Move()
    {
        if (stunCounter <= 0)
        {
            if (canMove > 0)
            {
                LayerMask mask = 192;
                if (Physics2D.Raycast(transform.position + (Vector3)lookDirection * 0.6f, lookDirection, 0.2f, mask).collider == null)
                {
                    yield return new WaitForFixedUpdate();
                    am.SetTrigger("Shoot");
                    GameObject coin = Instantiate(coinPrefab, transform.position + new Vector3(0.9f * lookDirection.x + 0.1f * Mathf.Abs(lookDirection.y), -0.3f * Mathf.Abs(lookDirection.x) + lookDirection.y, 0f), Quaternion.identity);
                    Coin_Movement coin_movement = coin.GetComponent<Coin_Movement>();
                    coin_movement.lookDirection = lookDirection;
                    coin_movement.gm = gm;
                }
            }
            canMove++;
            if (canMove == 3)
            {
                canMove = 0;
            }
            yield return new WaitForSeconds(0f);
        }
        stunCounter--;
    }

    public override void TakeDamage(int dmg)
    {
        currentHealth -= dmg;
    }

    public override void Stun()
    {
        stunCounter = 2;
    }
}
