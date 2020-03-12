using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonologueManager : MonoBehaviour
{
    [SerializeField]
    private GameObject npcMessage;

    private string currentText;

    private bool active;

    public void ActivateMonologue(bool condition, string message = "")
    {
        active = condition;
        npcMessage.SetActive(active);

        if(message != "")
        {
            StartCoroutine(ShowMessage(message));
        }
    }

    private IEnumerator ShowMessage(string mes)
    {
        for (int i = 0; i < mes.Length; i++)
        {
            currentText = mes.Substring(0, i);
            npcMessage.GetComponentInChildren<Text>().text = currentText;
            yield return new WaitForSeconds(0.01f);

            if(!active)
            {
                yield break;
            }
        }
    }
}
