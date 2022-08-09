using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WP_Movement : Enemy_Movement
{
    [SerializeField] BoxCollider2D standingCollider;
    [SerializeField] BoxCollider2D fallenCollider;
    [SerializeField] BoxCollider2D playerDetector;
    [SerializeField] Game_Manager gm;
    const int WOMP_INDEX = 0;
    private Rigidbody2D rb;
    private Animator am;
    private int currentHealth;
    private int maxHealth;
    public bool falling;
    public int numEnemiesInFall;
    public bool playerInFall;
    public int numCollidersInStanding;
    public int fallenCounter;
    private int stunCounter;

    // Start is called before the first frame update
    void Start()
    {
        stunCounter = 0;
        maxHealth = 30;
        currentHealth = maxHealth;
        if(Random.Range(0,2) == 1)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        falling = false;
        numEnemiesInFall = 0;
        playerInFall = false;
        fallenCounter = 0;
        numCollidersInStanding = 0;
        gm.enemies[WOMP_INDEX].Add(gameObject);
        rb = GetComponent<Rigidbody2D>();
        am = GetComponent<Animator>();
    }

    private void Update()
    {
        if (currentHealth <= 0)
        {
            gm.enemies[WOMP_INDEX].Remove(gameObject);
            Destroy(gameObject);
        }
    }

    public override IEnumerator Move()
    {
        //If I ever come back to this I should check positions before checking for collisions to not waste processing but game jam soooooo
        if (stunCounter <= 0)
        {
            if (fallenCounter == 1)
            {
                yield return new WaitForFixedUpdate();
                if (numCollidersInStanding == 0)
                {
                    GetUp();
                }
                else
                {
                    fallenCounter++;
                }
            }
            else
            {
                if (falling)
                {
                    yield return new WaitForFixedUpdate();
                    if (!(numEnemiesInFall > 0 && !playerInFall))
                    {
                        Fall();
                    }
                }
            }
            fallenCounter--;
        }
        stunCounter--;
    }

    private void Fall()
    {
        playerDetector.enabled = false;
        standingCollider.enabled = false;
        Vector2 position = rb.position;
        position += Vector2.down * 2;
        rb.MovePosition(position);
        fallenCollider.enabled = true;
        am.SetBool("Falling", false);
        falling = false;
        fallenCounter = 3;
        am.SetBool("Fallen", true);
    }

    private void GetUp()
    {
        fallenCollider.enabled = false;
        Vector2 position = rb.position;
        position += Vector2.up * 2;
        transform.position = position;
        standingCollider.enabled = true;
        fallenCounter = 0;
        am.SetBool("Fallen", false);
        playerDetector.enabled = true;
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
