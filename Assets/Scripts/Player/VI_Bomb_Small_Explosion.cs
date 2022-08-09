using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VI_Bomb_Small_Explosion : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision);
        VI_Movement vm = collision.GetComponent<VI_Movement>();
        if(vm != null)
        {
            vm.Die();
        }
        Enemy_Movement em = collision.GetComponent<Enemy_Movement>();
        if(em != null)
        {
            em.TakeDamage(15);
        }
    }
}
