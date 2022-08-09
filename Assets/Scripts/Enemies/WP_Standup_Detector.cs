using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WP_Standup_Detector : MonoBehaviour
{
    [SerializeField] WP_Movement wp;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        wp.numCollidersInStanding++;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        wp.numCollidersInStanding--;
    }
}
