using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Cooldown_UI_Manager : MonoBehaviour
{
    [SerializeField] VI_Action_Selector vas;
    [SerializeField] TextMeshProUGUI cd1;
    [SerializeField] TextMeshProUGUI cd2;
    [SerializeField] TextMeshProUGUI cd3;
    [SerializeField] TextMeshProUGUI cd4;

    // Update is called once per frame
    void Update()
    {
        cd1.enabled = false;
        cd2.enabled = false;
        cd3.enabled = false;
        cd4.enabled = false;
        if (vas.ability1Cooldown != 0)
        {
            cd1.enabled = true;
            cd1.text = vas.ability1Cooldown.ToString();
        }
        if (vas.ability2Cooldown != 0)
        {
            cd2.enabled = true;
            cd2.text = vas.ability2Cooldown.ToString();
        }
        if (vas.ability3Cooldown != 0)
        {
            cd3.enabled = true;
            cd3.text = vas.ability3Cooldown.ToString();
        }
        if(vas.ability4Cooldown != 0)
        {
            cd4.enabled = true;
            cd4.text = vas.ability4Cooldown.ToString();
        }
    }
}
