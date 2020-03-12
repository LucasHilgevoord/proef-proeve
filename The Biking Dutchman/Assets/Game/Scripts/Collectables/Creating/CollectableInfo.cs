using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Collectable", menuName = "New Collectable")]
public class CollectableInfo : ScriptableObject
{
    public string item;

    public Sprite sprite;
}
