using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece_Collisions : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        VI_Movement vi = collision.gameObject.GetComponent<VI_Movement>();
        if(vi != null)
        {
            vi.Die();
        }
    }
}
