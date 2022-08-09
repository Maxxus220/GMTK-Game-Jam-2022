using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WP_Player_Detecter : MonoBehaviour
{
    [SerializeField] WP_Movement wp;
    [SerializeField] Animator am;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        VI_Movement vi = collision.GetComponent<VI_Movement>();
        if(vi != null)
        {
            am.SetBool("Falling", true);
            wp.falling = true;
            wp.playerInFall = true;
        }
        Enemy_Movement em = collision.GetComponent<Enemy_Movement>();
        if(em != null)
        {
            wp.numEnemiesInFall++;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        VI_Movement vi = collision.GetComponent<VI_Movement>();
        if (vi != null)
        {
            wp.playerInFall = false;
        }
        Enemy_Movement em = collision.GetComponent<Enemy_Movement>();
        if (em != null)
        {
            wp.numEnemiesInFall--;
        }
    }
}
