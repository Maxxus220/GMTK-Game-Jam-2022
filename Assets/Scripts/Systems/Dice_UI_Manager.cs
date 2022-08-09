using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dice_UI_Manager : MonoBehaviour
{
    [SerializeField] Game_Manager gm;
    [SerializeField] Image die1;
    [SerializeField] Image die2;
    [SerializeField] Image die3;
    [SerializeField] Image die4;
    [SerializeField] Sprite die1Sprite;
    [SerializeField] Sprite die2Sprite;
    [SerializeField] Sprite die3Sprite;
    [SerializeField] Sprite die4Sprite;
    [SerializeField] Sprite die5Sprite;
    [SerializeField] Sprite die6Sprite;

    // Update is called once per frame
    void Update()
    {
        List<int> dice = gm.dice;
        int i;
        for(i = 0; i < dice.Count; i++)
        {
            switch(i)
            {
                case 0:
                    die1.enabled = true;
                    switch (dice[i])
                    {
                        case 1:
                            die1.sprite = die1Sprite;
                            break;
                        case 2:
                            die1.sprite = die2Sprite;
                            break;
                        case 3:
                            die1.sprite = die3Sprite;
                            break;
                        case 4:
                            die1.sprite = die4Sprite;
                            break;
                        case 5:
                            die1.sprite = die5Sprite;
                            break;
                        case 6:
                            die1.sprite = die6Sprite;
                            break;
                    }
                    break;
                case 1:
                    die2.enabled = true;
                    switch (dice[i])
                    {
                        case 1:
                            die2.sprite = die1Sprite;
                            break;
                        case 2:
                            die2.sprite = die2Sprite;
                            break;
                        case 3:
                            die2.sprite = die3Sprite;
                            break;
                        case 4:
                            die2.sprite = die4Sprite;
                            break;
                        case 5:
                            die2.sprite = die5Sprite;
                            break;
                        case 6:
                            die2.sprite = die6Sprite;
                            break;
                    }
                    break;
                case 2:
                    die3.enabled = true;
                    switch (dice[i])
                    {
                        case 1:
                            die3.sprite = die1Sprite;
                            break;
                        case 2:
                            die3.sprite = die2Sprite;
                            break;
                        case 3:
                            die3.sprite = die3Sprite;
                            break;
                        case 4:
                            die3.sprite = die4Sprite;
                            break;
                        case 5:
                            die3.sprite = die5Sprite;
                            break;
                        case 6:
                            die3.sprite = die6Sprite;
                            break;
                    }
                    break;
                case 3:
                    die4.enabled = true;
                    switch (dice[i])
                    {
                        case 1:
                            die4.sprite = die1Sprite;
                            break;
                        case 2:
                            die4.sprite = die2Sprite;
                            break;
                        case 3:
                            die4.sprite = die3Sprite;
                            break;
                        case 4:
                            die4.sprite = die4Sprite;
                            break;
                        case 5:
                            die4.sprite = die5Sprite;
                            break;
                        case 6:
                            die4.sprite = die6Sprite;
                            break;
                    }
                    break;
            }
        }
        for (int j = i; j < 4; j++)
        {
            switch (j)
            {
                case 0:
                    die1.enabled = false;
                    break;
                case 1:
                    die2.enabled = false;
                    break;
                case 2:
                    die3.enabled = false;
                    break;
                case 3:
                    die4.enabled = false;
                    break;
            }
        }
    }
}
