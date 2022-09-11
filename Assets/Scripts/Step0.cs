using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Step0 : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera camera;
    public Button[] buttons;
    int time = 0;
    private void OnMouseDown()
    {
        time++;
        if (time == 1)
        {
            camera.GetComponent<Painting>().enabled = true;
            buttons[0].gameObject.SetActive(true);
            buttons[1].gameObject.SetActive(true);
        }
    }
}
