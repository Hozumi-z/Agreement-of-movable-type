using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//���ë�ʽ�������ƶ���position_0������ʾ�װ�
public class CameraChange : MonoBehaviour
{
    public GameObject board;
    public Camera maincamera;
    public Transform pos;
    public GameObject gameO;
    public Text[] text;

    int time = 0;
    private void OnMouseDown()
    {
        time++;
        if (time == 1)
        {
            board.SetActive(true);
            maincamera.transform.SetPositionAndRotation(pos.position, pos.rotation);
            gameO.GetComponent<BoxCollider>().enabled = true;
            maincamera.GetComponent<Painting>().OnClickClear();
            text[0].gameObject.SetActive(false);
            text[1].gameObject.SetActive(false);
            text[2].gameObject.SetActive(true);
        }   
    }
}
