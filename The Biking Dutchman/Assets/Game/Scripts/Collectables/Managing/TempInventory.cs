using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempInventory : MonoBehaviour
{
    public int currentHamers;
    public int currentPlanks;

    [SerializeField]
    private List<CollectableInfo> inventory = new List<CollectableInfo>();

    private CollectableGUI collectableUI;

    private void Start()
    {
        collectableUI = GetComponent<CollectableGUI>();

        currentHamers = 0;
        currentPlanks = 0;
    }

    public void AddInventory(CollectableInfo collectable)
    {
        inventory.Add(collectable);
        AddToUI(collectable);
    }

    private void AddToUI(CollectableInfo c)
    {
        if(c.item == "hamer")
        {
            currentHamers++;
        }
        else if (c.item == "plank")
        {
            currentPlanks++;
        }

        collectableUI.LinkInventory();
    }
}
