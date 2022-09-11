using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class itemOnDrag : MonoBehaviour//, IBeginDragHandler, IDragHandler, IEndDragHandler
{/*
    public Transform originalParent;
    public Inventory myBag;
    public int currentItemID; //当前物品ID
    public GameObject[] pos;
    public void OnBeginDrag(PointerEventData eventData)
    {
        originalParent = transform.parent;
        currentItemID = originalParent.GetComponent<slot>().slotID;
        transform.SetParent(transform.parent.parent);
        transform.position = eventData.position;
        GetComponent<CanvasGroup>().blocksRaycasts = false; 
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
        Debug.Log(eventData.pointerCurrentRaycast.gameObject.name);  //输出鼠标当前位置下到第一个碰到物体的名字
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if(eventData.pointerCurrentRaycast.gameObject.name != null)
        {
            if (eventData.pointerCurrentRaycast.gameObject.name == "Item Image")  //判断下面物体的名字是：item image 那么互换位置
            {
                transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform.parent.parent);
                transform.position = eventData.pointerCurrentRaycast.gameObject.transform.parent.parent.position;
                //itemlist的物品存储位置改变
                var temp = myBag.itemList[currentItemID];
                myBag.itemList[currentItemID] =
                    myBag.itemList[eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<slot>().slotID];
                myBag.itemList[eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<slot>().slotID] = temp;

                eventData.pointerCurrentRaycast.gameObject.transform.parent.position = originalParent.position;
                eventData.pointerCurrentRaycast.gameObject.transform.parent.SetParent(originalParent);
                GetComponent<CanvasGroup>().blocksRaycasts = true;  //射线阻挡开启，不然无法再次选中移动物品
                return;
            }
            if (eventData.pointerCurrentRaycast.gameObject.name == "slot(Clone)")
            {
                //否则直接挂在检测到Slot下面
                transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform);
                transform.position = eventData.pointerCurrentRaycast.gameObject.transform.position;
                //itemList的物品存储位置改变
                myBag.itemList[eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<slot>().slotID] = myBag.itemList[currentItemID];
                //解决自己放在自己的问题
                if (eventData.pointerCurrentRaycast.gameObject.GetComponent<slot>().slotID != currentItemID)
                {
                    myBag.itemList[currentItemID] = null;
                }
                GetComponent<CanvasGroup>().blocksRaycasts = true;
                return;
            }
        }
       

        //其他任何位置都归位
        transform.SetParent(originalParent);
        transform.position = originalParent.position;
        GetComponent<CanvasGroup>().blocksRaycasts = true; 

    }
       
    */
       
}
