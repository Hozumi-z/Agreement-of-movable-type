using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class itemOnDrag : MonoBehaviour//, IBeginDragHandler, IDragHandler, IEndDragHandler
{/*
    public Transform originalParent;
    public Inventory myBag;
    public int currentItemID; //��ǰ��ƷID
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
        Debug.Log(eventData.pointerCurrentRaycast.gameObject.name);  //�����굱ǰλ���µ���һ���������������
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if(eventData.pointerCurrentRaycast.gameObject.name != null)
        {
            if (eventData.pointerCurrentRaycast.gameObject.name == "Item Image")  //�ж���������������ǣ�item image ��ô����λ��
            {
                transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform.parent.parent);
                transform.position = eventData.pointerCurrentRaycast.gameObject.transform.parent.parent.position;
                //itemlist����Ʒ�洢λ�øı�
                var temp = myBag.itemList[currentItemID];
                myBag.itemList[currentItemID] =
                    myBag.itemList[eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<slot>().slotID];
                myBag.itemList[eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<slot>().slotID] = temp;

                eventData.pointerCurrentRaycast.gameObject.transform.parent.position = originalParent.position;
                eventData.pointerCurrentRaycast.gameObject.transform.parent.SetParent(originalParent);
                GetComponent<CanvasGroup>().blocksRaycasts = true;  //�����赲��������Ȼ�޷��ٴ�ѡ���ƶ���Ʒ
                return;
            }
            if (eventData.pointerCurrentRaycast.gameObject.name == "slot(Clone)")
            {
                //����ֱ�ӹ��ڼ�⵽Slot����
                transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform);
                transform.position = eventData.pointerCurrentRaycast.gameObject.transform.position;
                //itemList����Ʒ�洢λ�øı�
                myBag.itemList[eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<slot>().slotID] = myBag.itemList[currentItemID];
                //����Լ������Լ�������
                if (eventData.pointerCurrentRaycast.gameObject.GetComponent<slot>().slotID != currentItemID)
                {
                    myBag.itemList[currentItemID] = null;
                }
                GetComponent<CanvasGroup>().blocksRaycasts = true;
                return;
            }
        }
       

        //�����κ�λ�ö���λ
        transform.SetParent(originalParent);
        transform.position = originalParent.position;
        GetComponent<CanvasGroup>().blocksRaycasts = true; 

    }
       
    */
       
}
