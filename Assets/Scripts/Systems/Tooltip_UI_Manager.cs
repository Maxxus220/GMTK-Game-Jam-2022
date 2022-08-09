using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tooltip_UI_Manager : MonoBehaviour
{
    [SerializeField] VI_Action_Selector vas;
    [SerializeField] Image tooltip;
    [SerializeField] Sprite tooltip1;
    [SerializeField] Sprite tooltip2;
    [SerializeField] Sprite tooltip3;
    [SerializeField] Sprite tooltip4;

    // Update is called once per frame
    void Update()
    {
        tooltip.enabled = true;
        switch(vas.selectedAbility)
        {
            case -1:
                tooltip.enabled = false;
                break;
            case 1:
                tooltip.sprite = tooltip1;
                break;
            case 2:
                tooltip.sprite = tooltip2;
                break;
            case 3:
                tooltip.sprite = tooltip3;
                break;
            case 4:
                tooltip.sprite = tooltip4;
                break;
        }
    }
}
