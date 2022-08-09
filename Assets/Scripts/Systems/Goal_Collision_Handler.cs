using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Goal_Collision_Handler : MonoBehaviour
{
    [SerializeField] Game_Manager gm;
    [SerializeField] Canvas winScreen;
    [SerializeField] VI_Movement vm;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerInput input = collision.GetComponent<PlayerInput>();
        if(input != null)
        {
            gm.started = false;
            input.enabled = false;
            winScreen.gameObject.SetActive(true);
        }
        Black_Betty bb = collision.GetComponent<Black_Betty>();
        if(bb != null)
        {
            vm.Die();
        }
    }
}
