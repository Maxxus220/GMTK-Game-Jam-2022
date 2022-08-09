using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Game_Manager : MonoBehaviour
{
    public List<GameObject>[] enemies;
    public List<int> dice;
    public List<bool> diceStatus;
    [SerializeField] GameObject vi;
    [SerializeField] VI_Movement vi_movement;
    [SerializeField] VI_Action_Selector vi_actions;
    private Vector2 startPos;
    [SerializeField] PlayerInput input;
    [SerializeField] Canvas deathScreen;
    [SerializeField] Animator am;
    public bool started;
    const int CAN_MOVE = 1;
    const int CANT_MOVE = 0;
    const int DISABLED = -1;
    const int WOMP_INDEX = 0;
    const int BLUE_INDEX = 1;
    const int RED_INDEX = 2;
    const int GREEN_INDEX = 3;
    const int RANGED_INDEX = 4;
    const int VIVIVI_COIN_INDEX = 5;
    const int VI_BOMB_INDEX = 6;
    const int SELECT_ABILITY = 0;
    public int j;

    // Start is called before the first frame update\
    void Awake()
    {
        startPos = new Vector2(vi_movement.transform.position.x, vi_movement.transform.position.y);
        started = false;
        dice = new List<int>();
        diceStatus = new List<bool>();
        enemies = new List<GameObject>[9];
        for(int i = 0; i < enemies.Length; i++)
        {
            enemies[i] = new List<GameObject>();
        }
        StartCoroutine(StartSequence());
    }

    // Update is called once per frame
    void Update()
    {
        //Slap?
        /**if(slap) {
            remove tiles
            set some sort of turn timer
        }*/
        if(started)
        {
            //Take turns
            if (vi_movement.canMove > DISABLED)
            {
                vi_movement.canMove = CAN_MOVE;
            }
            /**else if (vi_movement.canMove != DISABLED)
            {
                vi_movement.canMove = CANT_MOVE;
                vi_actions.selectState = DISABLED;
            }*/
        }
    }

    public void MoveEnemies()
    {
        for(int i = 0; i < enemies.Length; i++)
        {
            List<GameObject> enemy_type = enemies[i];
            if (enemy_type != null)
            {
                for (j = 0; j < enemy_type.Count; j++)
                {
                    Enemy_Movement em = enemy_type[j].GetComponent<Enemy_Movement>();
                    StartCoroutine(em.Move());
                }
            }
        }
    }

    public void Roll()
    {
        int die = Random.Range(1, 7);
        am.SetInteger("Face", die);
        if (dice.Count < 4)
        {
            dice.Add(die);
            diceStatus.Add(false);
        }
        else
        {
            int index = Random.Range(0, 4);
            dice.RemoveAt(index);
            diceStatus.RemoveAt(index);
            dice.Add(die);
            diceStatus.Add(false);
        }
    }

    public void Lose()
    {
        started = false;
        input.enabled = false;
        vi_movement.enabled = false;
        deathScreen.gameObject.SetActive(true);
    }

    IEnumerator StartSequence()
    {
        vi.GetComponent<Animator>().enabled = false;
        vi.GetComponent<BoxCollider2D>().enabled = false;
        vi.transform.position = startPos + Vector2.up * 10;
        for(int i = 0; i < 100; i++)
        {
            Vector2 position = vi.transform.position;
            position += Vector2.down * 0.1f;
            vi.transform.position = position;
            yield return new WaitForSeconds(0.01f);
        }
        vi.GetComponent<BoxCollider2D>().enabled = true;
        vi.GetComponent<Animator>().enabled = true;
        yield return new WaitForSeconds(0.4f);
        started = true;
        vi_actions.selectState = 0;
        vi_movement.canMove = 1;
    }
}
