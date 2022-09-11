using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Step_3 : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera camera;
    public Transform pos;
    public int time;
    private void OnMouseDown()
    {
        time++;
        if (time == 1)
        {
            camera.transform.SetPositionAndRotation(pos.position, pos.rotation);
            GetComponent<Typesetting>().enabled = true;
            GetComponent<BoxCollider>().isTrigger = false;
        }
    }
}
