using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    static InventoryManager instance;

    public Inventory myBag;
    public GameObject slotGrid;
    //public slot slotPrefab;
    public GameObject emptySlot;
    //public Text itemInformation;

    public List<GameObject> slots = new List<GameObject>();

    private void Awake()
    {
        if (instance != null)
            Destroy(this);
        instance = this;
    }
    private void OnEnable()
    {
        RefreshItem();
        //instance.itemInformation.text = "";

    }
    public static void UpdateItemInfo(string itemDescription)
    {
        //instance.itemInformation.text = itemDescription;
    }
   /* public static void CreateNewItem(item it)
    {
        slot newItem = Instantiate(instance.slotPrefab, instance.slotGrid.transform.position, Quaternion.identity);
        newItem.gameObject.transform.SetParent(instance.slotGrid.transform);
        newItem.slotItem = it;
        newItem.slotImage.sprite = it.itemImage;
        newItem.slotNum.text = it.itemHeld.ToString(); 
    }*/
    public static void RefreshItem()
    {
        //循环删除SlotGrid下的子集物体
        for(int i = 0; i < instance.slotGrid.transform.childCount; i++)
        {
            if (instance.slotGrid.transform.childCount == 0)
                break;
            Destroy(instance.slotGrid.transform.GetChild(i).gameObject);
            instance.slots.Clear();
        }

        //重新生成对于myBag里面的物品的slot
        for(int i = 0; i < instance.myBag.itemList.Count; i++)
        {
            //CreateNewItem(instance.myBag.itemList[i]);
            instance.slots.Add(Instantiate(instance.emptySlot));
            instance.slots[i].transform.SetParent(instance.slotGrid.transform);
            instance.slots[i].GetComponent<slot>().slotID = i;
            instance.slots[i].GetComponent<slot>().SetupSlot(instance.myBag.itemList[i]);
        }
    }
}
