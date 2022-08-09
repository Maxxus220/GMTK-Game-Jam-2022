using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JKL_UI_Manager : MonoBehaviour
{
    [SerializeField] VI_Action_Selector vas;
    [SerializeField] Image j;
    [SerializeField] Image k;
    [SerializeField] Image l;
    [SerializeField] Image semi;

    // Update is called once per frame
    void Update()
    {
        j.enabled = true;
        k.enabled = true;
        l.enabled = true;
        semi.enabled = true;
        j.color = new Color(1.0f, 1.0f, 1.0f, 0.7f);
        k.color = new Color(1.0f, 1.0f, 1.0f, 0.7f);
        l.color = new Color(1.0f, 1.0f, 1.0f, 0.7f);
        semi.color = new Color(1.0f, 1.0f, 1.0f, 0.7f);
        RectTransform jR = j.GetComponent<RectTransform>();
        RectTransform kR = k.GetComponent<RectTransform>();
        RectTransform lR = l.GetComponent<RectTransform>();
        RectTransform semiR = semi.GetComponent<RectTransform>();
        if (vas.selectState == -1 || vas.selectState == 3)
        {
            j.enabled = false;
            k.enabled = false;
            l.enabled = false;
            semi.enabled = false;
        }
        else if(vas.selectState == 0)
        {
            jR.anchorMax = new Vector2(0.5f, 0f);
            jR.anchorMin = new Vector2(0.5f, 0f);
            jR.anchoredPosition = new Vector3(-450, 162, 0);
            kR.anchorMax = new Vector2(0.5f, 0f);
            kR.anchorMin = new Vector2(0.5f, 0f);
            kR.anchoredPosition = new Vector3(-150, 162, 0);
            lR.anchorMax = new Vector2(0.5f, 0f);
            lR.anchorMin = new Vector2(0.5f, 0f);
            lR.anchoredPosition = new Vector3(150, 162, 0);
            semiR.anchorMax = new Vector2(0.5f, 0f);
            semiR.anchorMin = new Vector2(0.5f, 0f);
            semiR.anchoredPosition = new Vector3(450, 162, 0);
        }
        else if(vas.selectedAbility != 4) 
        {
            jR.anchorMax = new Vector2(0f, 0.5f);
            jR.anchorMin = new Vector2(0f, 0.5f);
            kR.anchorMax = new Vector2(0f, 0.5f);
            kR.anchorMin = new Vector2(0f, 0.5f);
            lR.anchorMax = new Vector2(0f, 0.5f);
            lR.anchorMin = new Vector2(0f, 0.5f);
            semiR.anchorMax = new Vector2(0f, 0.5f);
            semiR.anchorMin = new Vector2(0f, 0.5f);
            jR.anchoredPosition = new Vector3(101, 113f, 0);
            kR.anchoredPosition = new Vector3(101, 36f, 0);
            lR.anchoredPosition = new Vector3(101, -36f, 0);
            semiR.anchoredPosition = new Vector3(101, -113f, 0);
        }
        else if(vas.selectState == 2)
        {
            j.enabled = false;
            k.enabled = false;
            l.enabled = false;
            semi.enabled = false;
        }
        else
        {
            jR.anchorMax = new Vector2(0f, 0.5f);
            jR.anchorMin = new Vector2(0f, 0.5f);
            kR.anchorMax = new Vector2(0f, 0.5f);
            kR.anchorMin = new Vector2(0f, 0.5f);
            lR.anchorMax = new Vector2(0f, 0.5f);
            lR.anchorMin = new Vector2(0f, 0.5f);
            semiR.anchorMax = new Vector2(0f, 0.5f);
            semiR.anchorMin = new Vector2(0f, 0.5f);
            jR.anchoredPosition = new Vector3(101, 113f, 0);
            kR.anchoredPosition = new Vector3(101, 36f, 0);
            lR.anchoredPosition = new Vector3(101, -36f, 0);
            semiR.anchoredPosition = new Vector3(101, -113f, 0);
        }
    }
}
