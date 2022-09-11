using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChange : MonoBehaviour
{
    public Image[] image;
    public RawImage rawimage;
    public Text text;
    public GameObject he3;
    public GameObject butt;
    public GameObject shu;
    
    

    public void LoadScene2()
    {
        SceneManager.LoadScene(1);
    }

    public  void Introduce()
    {
        he3.SetActive(false);
        image[0].gameObject.SetActive(true);
        //image[1].gameObject.SetActive(false);
        text.gameObject.SetActive(true);
        butt.gameObject.SetActive(true);

    }

    public void Introduce_1()
    {
        rawimage.gameObject.SetActive(false);
        image[1].gameObject.SetActive(true);
        
    }

    public void EnterFanshu()
    {
        image[0].gameObject.SetActive(false);
        image[1].gameObject.SetActive(false);
        text.gameObject.SetActive(false);
        butt.gameObject.SetActive(false);
        shu.gameObject.SetActive(true);
    }
}
