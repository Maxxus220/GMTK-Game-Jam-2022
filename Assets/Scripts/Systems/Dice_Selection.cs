using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dice_Selection : MonoBehaviour
{
    [SerializeField] Image die1;
    [SerializeField] Image die2;
    [SerializeField] Image die3;
    [SerializeField] Image die4;
    [SerializeField] Game_Manager gm;
    [SerializeField] VI_Action_Selector vas;

    Color defaultColor = new Color(1f, 1f, 1f, 0.7f);
    Color selectedColor = new Color(1f, 1f, 1f, 1f);

    Vector3 default1 = new Vector3(36.6f, 113f, -1f);
    Vector3 default2 = new Vector3(36.6f, 36f, -1f);
    Vector3 default3 = new Vector3(36.6f, -36f, -1f);
    Vector3 default4 = new Vector3(36.6f, -113f, -1f);

    Vector3 spot1 = new Vector3(-483f, 42f, -1f);
    Vector3 spot2 = new Vector3(-420f, 42f, -1f);
    Vector3 spot3 = new Vector3(-183f, 42f, -1f);
    Vector3 spot4 = new Vector3(-120f, 42f, -1f);
    Vector3 spot5 = new Vector3(118f, 42f, -1f);
    Vector3 spot6 = new Vector3(183f, 42f, -1f);
    Vector3 spot7 = new Vector3(450f, 42f, -1f);

    private void Update()
    {
        RectTransform r1 = die1.GetComponent<RectTransform>();
        RectTransform r2 = die2.GetComponent<RectTransform>();
        RectTransform r3 = die3.GetComponent<RectTransform>();
        RectTransform r4 = die4.GetComponent<RectTransform>();
        r1.anchorMin = new Vector2(0f, 0.5f);
        r1.anchorMax = new Vector2(0f, 0.5f);
        r2.anchorMin = new Vector2(0f, 0.5f);
        r2.anchorMax = new Vector2(0f, 0.5f);
        r3.anchorMin = new Vector2(0f, 0.5f);
        r3.anchorMax = new Vector2(0f, 0.5f);
        r4.anchorMin = new Vector2(0f, 0.5f);
        r4.anchorMax = new Vector2(0f, 0.5f);
        r1.anchoredPosition = default1;
        r2.anchoredPosition = default2;
        r3.anchoredPosition = default3;
        r4.anchoredPosition = default4;
        die1.color = defaultColor;
        die2.color = defaultColor;
        die3.color = defaultColor;
        die4.color = defaultColor;
        switch (vas.selectedAbility)
        {
            case 1:
                switch(vas.selectedDie1)
                {
                    case 1:
                        r1.anchorMin = new Vector2(0.5f, 0f);
                        r1.anchorMax = new Vector2(0.5f, 0f);
                        die1.GetComponent<RectTransform>().anchoredPosition = spot1;
                        die1.color = selectedColor;
                        break;
                    case 2:
                        r2.anchorMin = new Vector2(0.5f, 0f);
                        r2.anchorMax = new Vector2(0.5f, 0f);
                        die2.GetComponent<RectTransform>().anchoredPosition = spot1;
                        die2.color = selectedColor;
                        break;
                    case 3:
                        r3.anchorMin = new Vector2(0.5f, 0f);
                        r3.anchorMax = new Vector2(0.5f, 0f);
                        die3.GetComponent<RectTransform>().anchoredPosition = spot1;
                        die3.color = selectedColor;
                        break;
                    case 4:
                        r4.anchorMin = new Vector2(0.5f, 0f);
                        r4.anchorMax = new Vector2(0.5f, 0f);
                        die4.GetComponent<RectTransform>().anchoredPosition = spot1;
                        die4.color = selectedColor;
                        break;
                }
                switch (vas.selectedDie2)
                {
                    case 1:
                        r1.anchorMin = new Vector2(0.5f, 0f);
                        r1.anchorMax = new Vector2(0.5f, 0f);
                        die1.GetComponent<RectTransform>().anchoredPosition = spot2;
                        die1.color = selectedColor;
                        break;
                    case 2:
                        r2.anchorMin = new Vector2(0.5f, 0f);
                        r2.anchorMax = new Vector2(0.5f, 0f);
                        die2.GetComponent<RectTransform>().anchoredPosition = spot2;
                        die2.color = selectedColor;
                        break;
                    case 3:
                        r3.anchorMin = new Vector2(0.5f, 0f);
                        r3.anchorMax = new Vector2(0.5f, 0f);
                        die3.GetComponent<RectTransform>().anchoredPosition = spot2;
                        die3.color = selectedColor;
                        break;
                    case 4:
                        r4.anchorMin = new Vector2(0.5f, 0f);
                        r4.anchorMax = new Vector2(0.5f, 0f);
                        die4.GetComponent<RectTransform>().anchoredPosition = spot2;
                        die4.color = selectedColor;
                        break;
                }
                break;
            case 2:
                switch (vas.selectedDie1)
                {
                    case 1:
                        r1.anchorMin = new Vector2(0.5f, 0f);
                        r1.anchorMax = new Vector2(0.5f, 0f);
                        die1.GetComponent<RectTransform>().anchoredPosition = spot3;
                        die1.color = selectedColor;
                        break;
                    case 2:
                        r2.anchorMin = new Vector2(0.5f, 0f);
                        r2.anchorMax = new Vector2(0.5f, 0f);
                        die2.GetComponent<RectTransform>().anchoredPosition = spot3;
                        die2.color = selectedColor;
                        break;
                    case 3:
                        r3.anchorMin = new Vector2(0.5f, 0f);
                        r3.anchorMax = new Vector2(0.5f, 0f);
                        die3.GetComponent<RectTransform>().anchoredPosition = spot3;
                        die3.color = selectedColor;
                        break;
                    case 4:
                        r4.anchorMin = new Vector2(0.5f, 0f);
                        r4.anchorMax = new Vector2(0.5f, 0f);
                        die4.GetComponent<RectTransform>().anchoredPosition = spot3;
                        die4.color = selectedColor;
                        break;
                }
                switch (vas.selectedDie2)
                {
                    case 1:
                        r1.anchorMin = new Vector2(0.5f, 0f);
                        r1.anchorMax = new Vector2(0.5f, 0f);
                        die1.GetComponent<RectTransform>().anchoredPosition = spot4;
                        die1.color = selectedColor;
                        break;
                    case 2:
                        r2.anchorMin = new Vector2(0.5f, 0f);
                        r2.anchorMax = new Vector2(0.5f, 0f);
                        die2.GetComponent<RectTransform>().anchoredPosition = spot4;
                        die2.color = selectedColor;
                        break;
                    case 3:
                        r3.anchorMin = new Vector2(0.5f, 0f);
                        r3.anchorMax = new Vector2(0.5f, 0f);
                        die3.GetComponent<RectTransform>().anchoredPosition = spot4;
                        die3.color = selectedColor;
                        break;
                    case 4:
                        r4.anchorMin = new Vector2(0.5f, 0f);
                        r4.anchorMax = new Vector2(0.5f, 0f);
                        die4.GetComponent<RectTransform>().anchoredPosition = spot4;
                        die4.color = selectedColor;
                        break;
                }
                break;
            case 3:
                switch (vas.selectedDie1)
                {
                    case 1:
                        r1.anchorMin = new Vector2(0.5f, 0f);
                        r1.anchorMax = new Vector2(0.5f, 0f);
                        die1.GetComponent<RectTransform>().anchoredPosition = spot5;
                        die1.color = selectedColor;
                        break;
                    case 2:
                        r2.anchorMin = new Vector2(0.5f, 0f);
                        r2.anchorMax = new Vector2(0.5f, 0f);
                        die2.GetComponent<RectTransform>().anchoredPosition = spot5;
                        die2.color = selectedColor;
                        break;
                    case 3:
                        r3.anchorMin = new Vector2(0.5f, 0f);
                        r3.anchorMax = new Vector2(0.5f, 0f);
                        die3.GetComponent<RectTransform>().anchoredPosition = spot5;
                        die3.color = selectedColor;
                        break;
                    case 4:
                        r4.anchorMin = new Vector2(0.5f, 0f);
                        r4.anchorMax = new Vector2(0.5f, 0f);
                        die4.GetComponent<RectTransform>().anchoredPosition = spot5;
                        die4.color = selectedColor;
                        break;
                }
                switch (vas.selectedDie2)
                {
                    case 1:
                        r1.anchorMin = new Vector2(0.5f, 0f);
                        r1.anchorMax = new Vector2(0.5f, 0f);
                        die1.GetComponent<RectTransform>().anchoredPosition = spot6;
                        die1.color = selectedColor;
                        break;
                    case 2:
                        r2.anchorMin = new Vector2(0.5f, 0f);
                        r2.anchorMax = new Vector2(0.5f, 0f);
                        die2.GetComponent<RectTransform>().anchoredPosition = spot6;
                        die2.color = selectedColor;
                        break;
                    case 3:
                        r3.anchorMin = new Vector2(0.5f, 0f);
                        r3.anchorMax = new Vector2(0.5f, 0f);
                        die3.GetComponent<RectTransform>().anchoredPosition = spot6;
                        die3.color = selectedColor;
                        break;
                    case 4:
                        r4.anchorMin = new Vector2(0.5f, 0f);
                        r4.anchorMax = new Vector2(0.5f, 0f);
                        die4.GetComponent<RectTransform>().anchoredPosition = spot6;
                        die4.color = selectedColor;
                        break;
                }
                break;
            case 4:
                switch (vas.selectedDie1)
                {
                    case 1:
                        r1.anchorMin = new Vector2(0.5f, 0f);
                        r1.anchorMax = new Vector2(0.5f, 0f);
                        die1.GetComponent<RectTransform>().anchoredPosition = spot7;
                        die1.color = selectedColor;
                        break;
                    case 2:
                        r2.anchorMin = new Vector2(0.5f, 0f);
                        r2.anchorMax = new Vector2(0.5f, 0f);
                        die2.GetComponent<RectTransform>().anchoredPosition = spot7;
                        die2.color = selectedColor;
                        break;
                    case 3:
                        r3.anchorMin = new Vector2(0.5f, 0f);
                        r3.anchorMax = new Vector2(0.5f, 0f);
                        die3.GetComponent<RectTransform>().anchoredPosition = spot7;
                        die3.color = selectedColor;
                        break;
                    case 4:
                        r4.anchorMin = new Vector2(0.5f, 0f);
                        r4.anchorMax = new Vector2(0.5f, 0f);
                        die4.GetComponent<RectTransform>().anchoredPosition = spot7;
                        die4.color = selectedColor;
                        break;
                }
                break;
        }
    }
}
