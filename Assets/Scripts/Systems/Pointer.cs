using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    [SerializeField] GameObject pointer;
    [SerializeField] VI_Movement vm;
    [SerializeField] VI_Action_Selector vas;
    [SerializeField] Sprite pointerL;
    [SerializeField] Sprite pointerR;
    [SerializeField] Sprite pointerU;
    [SerializeField] Sprite pointerD;

    // Update is called once per frame
    void Update()
    {
        pointer.GetComponent<SpriteRenderer>().enabled = true;
        if (vas.selectState == -1 || vas.selectState == 0)
        {
            pointer.GetComponent<SpriteRenderer>().enabled = false;
        }
        switch(vm.lookDirection.x)
        {
            case 1:
                pointer.GetComponent<SpriteRenderer>().sprite = pointerR;
                transform.localPosition = new Vector3(0.6f, 0f, 0f);
                break;
            case -1:
                pointer.GetComponent<SpriteRenderer>().sprite = pointerL;
                transform.localPosition = new Vector3(-0.6f, 0f, 0f);
                break;
        }
        switch(vm.lookDirection.y)
        {
            case 1:
                pointer.GetComponent<SpriteRenderer>().sprite = pointerU;
                transform.localPosition = new Vector3(0f, 0.65f, 0f);
                break;
            case -1:
                pointer.GetComponent<SpriteRenderer>().sprite = pointerD;
                transform.localPosition = new Vector3(0f, -0.7f, 0f);
                break;
        }
    }
}
