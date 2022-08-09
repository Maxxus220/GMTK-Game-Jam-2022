using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VI_Bomb : Enemy_Movement
{
    [SerializeField] BoxCollider2D small;
    [SerializeField] BoxCollider2D bigger;
    [SerializeField] ParticleSystem ps;
    [SerializeField] GameObject bigBox;
    [SerializeField] GameObject littleBox;
    public Game_Manager gm;
    private int counter;
    public bool big;

    // Start is called before the first frame update
    void Start()
    {
        counter = 0;
        gm.enemies[6].Add(gameObject);
        if(big)
        {
            bigBox.GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            littleBox.GetComponent<SpriteRenderer>().enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override IEnumerator Move()
    {
        counter++;
        if(counter == 3)
        {
            yield return new WaitForFixedUpdate();
            if(big)
            {
                bigger.enabled = true;
            }
            else
            {
                small.enabled = true;
            }
            yield return new WaitForFixedUpdate();
            gm.enemies[6].Remove(gameObject);
            Destroy(gameObject);
        }
    }

    public override void TakeDamage(int dmg)
    {

    }

    public override void Stun()
    {

    }
}
