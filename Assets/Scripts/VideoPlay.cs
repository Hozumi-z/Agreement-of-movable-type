using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VideoPlay : MonoBehaviour
{
    public GameObject Panel;
    public Image Step_2;
    public void Play()
    {
        Panel.SetActive(true);
        Step_2.gameObject.SetActive(true);
    }

    public void End()
    {
        Panel.SetActive(false);
        Step_2.gameObject.SetActive(false);
    }
}
