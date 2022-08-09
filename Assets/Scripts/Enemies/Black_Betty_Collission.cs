using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Black_Betty_Collission : MonoBehaviour
{
    [SerializeField] Game_Manager gm;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        VI_Movement vi = collision.gameObject.GetComponent<VI_Movement>();
        if (vi != null)
        {
            vi.Die();
            return;
        }
        RP_Movement rp = collision.gameObject.GetComponent<RP_Movement>();
        if (rp != null)
        {
            gm.enemies[2].Remove(rp.gameObject);
            Destroy(rp.gameObject);
            return;
        }
        GP_Movement gp = collision.gameObject.GetComponent<GP_Movement>();
        if(gp != null)
        {
            gm.enemies[3].Remove(gp.gameObject);
            Destroy(gp.gameObject);
            return;
        }
        BP_Movement bp = collision.gameObject.GetComponent<BP_Movement>();
        if (bp != null)
        {
            gm.enemies[1].Remove(bp.gameObject);
            Destroy(bp.gameObject);
            return;
        }
        WP_Movement wp = collision.gameObject.GetComponent<WP_Movement>();
        if (wp != null)
        {
            gm.enemies[0].Remove(wp.gameObject);
            Destroy(wp.gameObject);
            return;
        }
        VIVIVI_Movement vivivi = collision.gameObject.GetComponent<VIVIVI_Movement>();
        if (vivivi != null)
        {
            gm.enemies[4].Remove(vivivi.gameObject);
            Destroy(vivivi.gameObject);
            return;
        }
        Coin_Movement coin = collision.gameObject.GetComponent<Coin_Movement>();
        if (coin != null)
        {
            gm.enemies[5].Remove(coin.gameObject);
            Destroy(coin.gameObject);
            return;
        }
        VI_Bomb bomb = collision.gameObject.GetComponent<VI_Bomb>();
        if(bomb != null)
        {
            gm.enemies[6].Remove(bomb.gameObject);
            Destroy(bomb.gameObject);
            return;
        }
    }
}
