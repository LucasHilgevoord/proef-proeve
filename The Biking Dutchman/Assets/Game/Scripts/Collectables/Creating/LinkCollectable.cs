using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkCollectable : MonoBehaviour
{
    public CollectableInfo collectable;

    public void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = collectable.sprite;
        gameObject.tag = "Collectable";
    }
}

