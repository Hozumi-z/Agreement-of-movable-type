using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyBag : MonoBehaviour
{
    public GameObject Bag;
    bool isOpen;

    public void OpenMyBag()
    {
          isOpen = !isOpen;
          Bag.SetActive(isOpen);
        
    }
    public void CloseMyBag()
    {
        isOpen = !isOpen;
        Bag.SetActive(isOpen);

    }
    
}
