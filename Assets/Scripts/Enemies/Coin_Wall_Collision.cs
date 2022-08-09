using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_Wall_Collision : MonoBehaviour
{
    const int VIVIVI_COIN_INDEX = 5;
    private Rigidbody2D rb;
    private Coin_Movement cm;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cm = GetComponent<Coin_Movement>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        VI_Movement vi = collision.gameObject.GetComponent<VI_Movement>();
        if(vi != null)
        {
            vi.Die();
        }
        else if (collision.collider.tag == "Tilemap")
        {
            Coin_Movement cm = GetComponent<Coin_Movement>();
            cm.gm.enemies[VIVIVI_COIN_INDEX].Remove(gameObject);
            Destroy(gameObject);
        }
    }
}
