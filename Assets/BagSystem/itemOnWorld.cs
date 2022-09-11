using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemOnWorld : MonoBehaviour
{
    public static int curid = -1;
    public item thisItem;
    public Inventory thisInventory;
    //public int curID;
    public Transform[] pos;
    //public GameObject slo;

    private void Start()
    {
        
    }

    private void OnMouseDown()
    {
        curid++;
        Config.id++;
        Debug.Log(curid);
        Debug.Log(Config.id);
        AddNewItem();
        gameObject.transform.position = pos[curid].position;
        gameObject.GetComponent<itemOnWorld>().enabled = false;
        //gameObject.GetComponent<Typesetting>().enabled = true;
    }
    public void AddNewItem()
    {
        if (!thisInventory.itemList.Contains(thisItem))
        {
            //thisInventory.itemList.Add(thisItem);
           // InventoryManager.CreatNewItem(thisItem);
           for(int i = 0; i < thisInventory.itemList.Count; i++)
            {
                if(thisInventory.itemList[i] == null)
                {
                    thisInventory.itemList[i] = thisItem;
                    break;
                }
            }
        }
        else
        {
            thisItem.itemHeld += 1; 
        }
        InventoryManager.RefreshItem();
    }
    public void ReSetup()
    {

    }
}
