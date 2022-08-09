using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ability_Selector : MonoBehaviour
{
    [SerializeField] Image ability1;
    [SerializeField] Image ability2;
    [SerializeField] Image ability3;
    [SerializeField] Image ability4;
    [SerializeField] VI_Action_Selector vas;

    void Update()
    {
        ability1.color = new Color(1f, 1f, 1f, 0.7f);
        ability2.color = new Color(1f, 1f, 1f, 0.7f);
        ability3.color = new Color(1f, 1f, 1f, 0.7f);
        ability4.color = new Color(1f, 1f, 1f, 0.7f);
        switch (vas.selectedAbility)
        {
            case 1:
                ability1.color = new Color(1f, 1f, 1f, 1f);
                break;
            case 2:
                ability2.color = new Color(1f, 1f, 1f, 1f);
                break;
            case 3:
                ability3.color = new Color(1f, 1f, 1f, 1f);
                break;
            case 4:
                ability4.color = new Color(1f, 1f, 1f, 1f);
                break;
        }
    }
}
