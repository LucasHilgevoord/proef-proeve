using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupCollectable : MonoBehaviour
{
    private TempInventory inventory;

    private void Start()
    {
        inventory = GetComponent<TempInventory>();
    }

    private void Update()
    {
        Pickup();
    }

    private void Pickup()
    {
        RaycastHit hit;
            
        Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 1000f);

        if (hit.collider != null && Input.GetMouseButtonUp(0))
        {
            if (hit.collider.tag == "Collectable")
            {
                Collect(hit.collider.gameObject.GetComponent<LinkCollectable>().collectable);
                Destroy(hit.collider.gameObject);
            }
        }
    }

    private void Collect(CollectableInfo collectable)
    {
        inventory.AddInventory(collectable);
    }
}
