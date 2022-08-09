using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_Collision : Enemy_Movement
{
    public Game_Manager gm;
    [SerializeField] int counter;

    private void Start()
    {
        counter = 3;
        gm.enemies[8].Add(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        VI_Movement vm = collision.GetComponent<VI_Movement>();
        if(vm != null)
        {
            vm.Die();
        }
        Enemy_Movement em = collision.GetComponent<Enemy_Movement>();
        if(em != null)
        {
            gm.enemies[8].Remove(gameObject);
            Destroy(gameObject);
        }
    }

    public override void Stun()
    {
    }

    public override void TakeDamage(int dmg)
    {
    }

    public override IEnumerator Move()
    {
        counter--;
        if(counter == 0)
        {
            gm.enemies[8].Remove(gameObject);
            gm.j--;
            Destroy(gameObject);
        }
        yield return new WaitForSeconds(0f);
    }
}
