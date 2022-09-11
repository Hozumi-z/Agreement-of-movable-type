using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Item", menuName = "BagSystem/New Inventory")]
public class Inventory : ScriptableObject
{
    public List<item> itemList = new List<item>();
}
