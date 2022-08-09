using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class VI_Action_Selector : MonoBehaviour
{
    [SerializeField] Game_Manager gm;
    [SerializeField] VI_Movement vm;
    [SerializeField] GameObject coin;
    [SerializeField] float projectileSpeed;
    [SerializeField] GameObject bomb;
    [SerializeField] GameObject stun;
    [SerializeField] float stunSpeed;
    private Animator am;
    private PlayerInput input;
    private InputAction selectJ;
    private InputAction selectK;
    private InputAction selectL;
    private InputAction selectSemicolon;
    private InputAction escape;
    private InputAction enter;
    public int selectState;
    public int selectedAbility;
    [SerializeField] public int selectedDie1;
    [SerializeField] public int selectedDie2;
    const int DISABLED = -1;
    const int SELECT_ABILITY = 0;
    const int SELECT_DICE_1 = 1;
    const int SELECT_DICE_2 = 2;
    const int FULL = 3;

    public int ability1Cooldown;
    public int ability2Cooldown;
    public int ability3Cooldown;
    public int ability4Cooldown;

    private void Awake()
    {
        am = GetComponent<Animator>();
        selectState = DISABLED;
        selectedAbility = -1;
        selectedDie1 = -1;
        selectedDie2 = -1;
        input = GetComponent<PlayerInput>();
        selectJ = input.actions["Select 1"];
        selectK = input.actions["Select 2"];
        selectL = input.actions["Select 3"];
        selectSemicolon = input.actions["Select 4"];
        selectJ.performed += SelectJ;
        selectK.performed += SelectK;
        selectL.performed += SelectL;
        selectSemicolon.performed += SelectSemiColon;
        escape = input.actions["Back"];
        escape.performed += Escape;
        enter = input.actions["Confirm"];
        enter.performed += Confirm;
    }

    private void OnDisable()
    {
        selectJ.performed -= SelectJ;
        selectK.performed -= SelectK;
        selectL.performed -= SelectL;
        escape.performed -= Escape;
        enter.performed -= Confirm;
    }

    private void Update()
    {
        if (selectState != DISABLED && selectState != SELECT_ABILITY && vm.canMove != -1)
        {
            vm.canMove = -2;
        }
        else if ((selectState == DISABLED || selectState == SELECT_ABILITY) && vm.canMove == -2)
        {
            vm.canMove = 1;
        }
        
    }

    private void SelectJ(InputAction.CallbackContext context)
    {
        if(selectState == SELECT_ABILITY)
        {
            selectedAbility = 1;
            selectState = SELECT_DICE_1;
            StartCoroutine(ActionDelay(0.075f));
            StartCoroutine(vm.ActionTaken(0.075f));
        }
        else if(selectState == SELECT_DICE_1)
        {
            if (gm.dice.Count >= 1 && gm.diceStatus[0] == false)
            {
                selectedDie1 = 1;
                selectState = SELECT_DICE_2;
                gm.diceStatus[0] = true;
                StartCoroutine(ActionDelay(0.075f));
                StartCoroutine(vm.ActionTaken(0.075f));
            }
        }
        else if (selectState == SELECT_DICE_2 && selectedAbility != 4)
        {
            if (gm.dice.Count >= 1 && gm.diceStatus[0] == false)
            {
                selectedDie2 = 1;
                selectState = FULL;
                gm.diceStatus[0] = true;
                StartCoroutine(ActionDelay(0.075f));
                StartCoroutine(vm.ActionTaken(0.075f));
            }
        }
    }

    private void SelectK(InputAction.CallbackContext context)
    {
        if (selectState == SELECT_ABILITY)
        {
            selectedAbility = 2;
            selectState = SELECT_DICE_1;
            StartCoroutine(ActionDelay(0.075f));
            StartCoroutine(vm.ActionTaken(0.075f));
        }
        else if (selectState == SELECT_DICE_1)
        {
            if (gm.dice.Count >= 2 && gm.diceStatus[1] == false)
            {
                selectedDie1 = 2;
                selectState = SELECT_DICE_2;
                gm.diceStatus[1] = true;
                StartCoroutine(ActionDelay(0.075f));
                StartCoroutine(vm.ActionTaken(0.075f));
            }
        }
        else if (selectState == SELECT_DICE_2 && selectedAbility != 4)
        {
            if (gm.dice.Count >= 2 && gm.diceStatus[1] == false)
            {
                selectedDie2 = 2;
                selectState = FULL;
                gm.diceStatus[1] = true;
                StartCoroutine(ActionDelay(0.075f));
                StartCoroutine(vm.ActionTaken(0.075f));
            }
        }
    }

    private void SelectL(InputAction.CallbackContext context)
    {
        if (selectState == SELECT_ABILITY)
        {
            selectedAbility = 3;
            selectState = SELECT_DICE_1;
            StartCoroutine(ActionDelay(0.075f));
            StartCoroutine(vm.ActionTaken(0.075f));
        }
        else if (selectState == SELECT_DICE_1)
        {
            if (gm.dice.Count >= 3 && gm.diceStatus[2] == false)
            {
                selectedDie1 = 3;
                selectState = SELECT_DICE_2;
                gm.diceStatus[2] = true;
                StartCoroutine(ActionDelay(0.075f));
                StartCoroutine(vm.ActionTaken(0.075f));
            }
        }
        else if (selectState == SELECT_DICE_2 && selectedAbility != 4)
        {
            if (gm.dice.Count >= 3 && gm.diceStatus[2] == false)
            {
                selectedDie2 = 3;
                selectState = FULL;
                gm.diceStatus[2] = true;
                StartCoroutine(ActionDelay(0.075f));
                StartCoroutine(vm.ActionTaken(0.075f));
            }
        }
    }

    private void SelectSemiColon(InputAction.CallbackContext context)
    {
        if (selectState == SELECT_ABILITY)
        {
            selectedAbility = 4;
            selectState = SELECT_DICE_1;
            StartCoroutine(ActionDelay(0.075f));
            StartCoroutine(vm.ActionTaken(0.075f));
        }
        else if (selectState == SELECT_DICE_1)
        {
            if (gm.dice.Count >= 4 && gm.diceStatus[3] == false)
            {
                selectedDie1 = 4;
                selectState = SELECT_DICE_2;
                gm.diceStatus[3] = true;
                StartCoroutine(ActionDelay(0.075f));
                StartCoroutine(vm.ActionTaken(0.075f));
            }
        }
        else if (selectState == SELECT_DICE_2 && selectedAbility != 4)
        {
            if (gm.dice.Count >= 4 && gm.diceStatus[3] == false)
            {
                selectedDie2 = 4;
                selectState = FULL;
                gm.diceStatus[3] = true;
                StartCoroutine(ActionDelay(0.075f));
                StartCoroutine(vm.ActionTaken(0.075f));
            }
        }
    }

    private void Escape(InputAction.CallbackContext context)
    {
        if(selectState == SELECT_DICE_1)
        {
            selectedAbility = -1;
            selectState = SELECT_ABILITY;
            StartCoroutine(ActionDelay(0.075f));
            StartCoroutine(vm.ActionTaken(0.075f));
        }
        else if(selectState == SELECT_DICE_2)
        {
            gm.diceStatus[selectedDie1 - 1] = false;
            selectedDie1 = -1;
            selectState = SELECT_DICE_1;
            StartCoroutine(ActionDelay(0.075f));
            StartCoroutine(vm.ActionTaken(0.075f));
        }
        else if(selectState == FULL)
        {
            gm.diceStatus[selectedDie2 - 1] = false;
            selectedDie2 = -1;
            selectState = SELECT_DICE_2;
            StartCoroutine(ActionDelay(0.075f));
            StartCoroutine(vm.ActionTaken(0.075f));
        }

    }

    private void Confirm(InputAction.CallbackContext context)
    {
        if(selectState == SELECT_DICE_2)
        {
            switch(selectedAbility)
            {
                case 4:
                    if (CheckAbility4(gm.dice[selectedDie1 - 1]) && ability4Cooldown == 0)
                    {
                        UseAbility4(gm.dice[selectedDie1 - 1]);
                        selectState = SELECT_ABILITY;
                        StartCoroutine(ActionDelay(0.075f));
                        StartCoroutine(vm.ActionTaken(0.075f));
                        gm.dice.RemoveAt(selectedDie1 - 1);
                        gm.diceStatus.RemoveAt(selectedDie1 - 1);
                        selectedDie1 = -1;
                        selectedAbility = -1;
                        selectState = SELECT_ABILITY;
                    }
                    break;
            }
        }
        else if(selectState == FULL)
        {
            switch (selectedAbility)
            {
                case 1:
                    if (CheckAbility1(gm.dice[selectedDie1 - 1], gm.dice[selectedDie2 - 1]) && ability1Cooldown == 0)
                    {
                        UseAbility1(gm.dice[selectedDie1 - 1], gm.dice[selectedDie2 - 1]);
                        selectState = SELECT_ABILITY;
                        StartCoroutine(ActionDelay(1.2f));
                        StartCoroutine(vm.ActionTaken(1.2f));
                        if (selectedDie1 > selectedDie2)
                        {
                            gm.dice.RemoveAt(selectedDie1 - 1);
                            gm.diceStatus.RemoveAt(selectedDie1 - 1);
                            gm.dice.RemoveAt(selectedDie2 - 1);
                            gm.diceStatus.RemoveAt(selectedDie2 - 1);
                        }
                        else
                        {
                            gm.dice.RemoveAt(selectedDie2 - 1);
                            gm.diceStatus.RemoveAt(selectedDie2 - 1);
                            gm.dice.RemoveAt(selectedDie1 - 1);
                            gm.diceStatus.RemoveAt(selectedDie1 - 1);
                        }
                        selectedDie1 = -1;
                        selectedDie2 = -1;
                        selectedAbility = -1;
                    }
                    break;
                case 2:
                    if (CheckAbility2(gm.dice[selectedDie1 - 1], gm.dice[selectedDie2 - 1]) && ability2Cooldown == 0)
                    {
                        UseAbility2(gm.dice[selectedDie1 - 1], gm.dice[selectedDie2 - 1]);
                        selectState = SELECT_ABILITY;
                        StartCoroutine(ActionDelay(0.075f));
                        StartCoroutine(vm.ActionTaken(0.075f));
                        if (selectedDie1 > selectedDie2)
                        {
                            gm.dice.RemoveAt(selectedDie1 - 1);
                            gm.diceStatus.RemoveAt(selectedDie1 - 1);
                            gm.dice.RemoveAt(selectedDie2 - 1);
                            gm.diceStatus.RemoveAt(selectedDie2 - 1);
                        }
                        else
                        {
                            gm.dice.RemoveAt(selectedDie2 - 1);
                            gm.diceStatus.RemoveAt(selectedDie2 - 1);
                            gm.dice.RemoveAt(selectedDie1 - 1);
                            gm.diceStatus.RemoveAt(selectedDie1 - 1);
                        }
                        selectedDie1 = -1;
                        selectedDie2 = -1;
                        selectedAbility = -1;
                    }
                    break;
                case 3:
                    if (CheckAbility3(gm.dice[selectedDie1 - 1], gm.dice[selectedDie2 - 1]) && ability3Cooldown == 0)
                    {
                        UseAbility3(gm.dice[selectedDie1 - 1], gm.dice[selectedDie2 - 1]);
                        selectState = SELECT_ABILITY;
                        StartCoroutine(ActionDelay(0.075f));
                        StartCoroutine(vm.ActionTaken(0.075f));
                        if (selectedDie1 > selectedDie2)
                        {
                            gm.dice.RemoveAt(selectedDie1 - 1);
                            gm.diceStatus.RemoveAt(selectedDie1 - 1);
                            gm.dice.RemoveAt(selectedDie2 - 1);
                            gm.diceStatus.RemoveAt(selectedDie2 - 1);
                        }
                        else
                        {
                            gm.dice.RemoveAt(selectedDie2 - 1);
                            gm.diceStatus.RemoveAt(selectedDie2 - 1);
                            gm.dice.RemoveAt(selectedDie1 - 1);
                            gm.diceStatus.RemoveAt(selectedDie1 - 1);
                        }
                        selectedDie1 = -1;
                        selectedDie2 = -1;
                        selectedAbility = -1;
                    }
                    break;
            }
        }
    }

    private void UseAbility1(int die1, int die2)
    {
        ability1Cooldown = 2;
        StartCoroutine(Ability1Helper(die2));
    }

    private IEnumerator Ability1Helper(int die2)
    {
        float yChange = -1;
        if(vm.lookDirection.y > 0)
        {
            yChange = 1;
        }
        else if (vm.lookDirection.y == 0)
        {
            yChange = 0;
        }
        else
        {
            yChange = -0.4f;
        }
        for(int i = 0; i < die2; i++)
        {
            am.SetTrigger("Shoot");
            GameObject newCoin = Instantiate(coin, transform.position + new Vector3(0.53f * vm.lookDirection.x, -0.2f + yChange, 0f), Quaternion.identity);
            VI_Projectile projectile = newCoin.GetComponent<VI_Projectile>();
            projectile.lookDirection = vm.lookDirection;
            projectile.speed = projectileSpeed;
            if(die2 == 1)
            {
                projectile.damage = 10;
            }
            else
            {
                projectile.damage = 1;
            }
            yield return new WaitForSeconds(0.2f);
        }
    }

    private void UseAbility2(int die1, int die2)
    {
        if(die1 == die2)
        {
            ability2Cooldown = die1;
        }
        else
        {
            ability2Cooldown = die1 + die2;
        }
        GameObject newStun = Instantiate(stun, transform.position + (Vector3)vm.lookDirection, Quaternion.identity);
        VI_Stun projectile = newStun.GetComponent<VI_Stun>();
        projectile.lookDirection = vm.lookDirection;
        projectile.speed = projectileSpeed;
    }

    private void UseAbility3(int die1, int die2)
    {
        ability3Cooldown = 5;
        GameObject newBomb = Instantiate(bomb, transform.position + (Vector3)vm.lookDirection, Quaternion.identity);
        VI_Bomb vi_bomb = newBomb.GetComponent<VI_Bomb>();
        if (die1 == die2)
        {
            vi_bomb.big = true;
        }
        else
        {
            vi_bomb.big = false;
        }
        vi_bomb.gm = gm;
    }

    private void UseAbility4(int die1)
    {
        ability4Cooldown = 2;
        gm.dice.Add(Random.Range(1, 7));
        gm.diceStatus.Add(false);
    }

    private bool CheckAbility1(int die1, int die2)
    {
        if(die1 == 1 || die1 == 3)
        {
            return true;
        }
        return false;
    }

    private bool CheckAbility2(int die1, int die2)
    {
        if(die1 > 1 && die1 < 6 && die2 > 1 && die2 < 6)
        {
            return true;
        }
        return false;
    }

    private bool CheckAbility3(int die1, int die2)
    {
        LayerMask mask = 32960;
        RaycastHit2D ray = Physics2D.Raycast(transform.position, vm.lookDirection, 1f, mask);
        if(ray.collider != null)
        {
            return false;
        }
        if(die1 + die2 >= 10)
        {
            return true;
        }
        return false;
    }

    private bool CheckAbility4(int die1)
    {
        return true;
    }

    IEnumerator ActionDelay(float time)
    {
        if (selectState != DISABLED)
        {
            int temp = selectState;
            selectState = DISABLED;
            yield return new WaitForSeconds(time);
            selectState = temp;
        }
    }
}
