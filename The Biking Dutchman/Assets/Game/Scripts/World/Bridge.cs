using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    [SerializeField]
    private TempInventory inv;

    private void OnMouseDown()
    {
        if (inv.currentPlanks == 2 || inv.currentHamers == 2)
        {
            StartCoroutine(Camera.main.GetComponent<FadeCamera>().FadeIn(1));
        }
    }
}
