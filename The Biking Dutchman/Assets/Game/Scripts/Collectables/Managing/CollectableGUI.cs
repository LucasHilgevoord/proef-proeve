using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectableGUI : MonoBehaviour
{
    //////TEMP!
    public int hamersNeeded = 2;
    public int planksNeeded = 2;
    //////TEMP!

    [SerializeField]
    private Text hamerAmountText;

    [SerializeField]
    private Text plankAmountText;

    [SerializeField]
    private Animator animatorInv;

    private TempInventory inventory;

    private void Start()
    {
        inventory = GetComponent<TempInventory>();
        LinkInventory();
    }

    public void LinkInventory()
    {
        hamerAmountText.text = inventory.currentHamers.ToString() + "/" + hamersNeeded.ToString();
        plankAmountText.text = inventory.currentPlanks.ToString() + "/" + planksNeeded.ToString();
    }

    public void OpenInventory()
    {
        if(!animatorInv.GetBool("Inventory"))
        {
            animatorInv.SetBool("Inventory", true);
        }
        else
        {
            animatorInv.SetBool("Inventory", false);
        }

    }
}
