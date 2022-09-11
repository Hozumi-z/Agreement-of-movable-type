using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    public Camera camera;
    public RawImage rawImage;
    public Text[] tips;
    public Button[] buttons;
    public Transform[] positions;
    public GameObject[] gameObjects;
    public Animator animator;
    public Light light;

    public bool flag;
    
    private void Start()
    {
        camera.gameObject.transform.SetPositionAndRotation(positions[0].position, positions[0].rotation);
        tips[0].gameObject.SetActive(true);
        flag = false;
        animator.speed = 0;
    }

    public void Step_0_Text_toEnterWrite()
    {
        tips[1].gameObject.SetActive(true);
        camera.gameObject.transform.SetPositionAndRotation(positions[1].position, positions[1].rotation);
        gameObjects[0].GetComponent<BoxCollider>().enabled = true;
    }

    public void Step_0_Button_toExitWrite()
    {
        camera.tag = "MainCamera";
    }

    public void Step_3_Image_toExitVedio()
    {
        tips[2].gameObject.SetActive(false);
        tips[3].gameObject.SetActive(true);
        rawImage.gameObject.SetActive(false);
        buttons[0].gameObject.SetActive(false);
        buttons[1].gameObject.SetActive(false);

        //循环赋予材质
        for(int c = 0; c < Config.id+1; c++)
        {
            GameObject.Find("Word_" + c).GetComponent<MeshRenderer>().materials[1].SetTexture("_DispTex", Resources.Load("Word" + c) as Texture2D);
        }
    }
    public void Step_3_Text_toEnterJianzi()
    {
        camera.transform.SetPositionAndRotation(positions[3].position, positions[3].rotation);
        tips[3].gameObject.SetActive(false);
        tips[4].gameObject.SetActive(true);
        light.gameObject.SetActive(true);
    }

    public void Step_3_Text_toExitJianzi()
    {
        
        camera.transform.SetPositionAndRotation(positions[0].position, positions[0].rotation);
        tips[4].gameObject.SetActive(false);
        tips[5].gameObject.SetActive(true);
        light.gameObject.SetActive(false);
    }

    public void Step_4_Text_toEnterTypeSetting()
    {
        camera.gameObject.transform.SetPositionAndRotation(positions[2].position, positions[2].rotation);
        tips[6].gameObject.SetActive(true);
        buttons[2].gameObject.SetActive(true);
        gameObjects[2].GetComponent<Typesetting>().enabled = true;
    }

    public void Step_4_Button_toExitTypeSetting()
    {
        camera.gameObject.transform.SetPositionAndRotation(positions[0].position, positions[0].rotation);
        tips[5].gameObject.SetActive(false);
        tips[6].gameObject.SetActive(false);
        tips[7].gameObject.SetActive(true);
        gameObjects[2].GetComponent<Typesetting>().enabled = false;
        buttons[2].gameObject.SetActive(false);
    }

    public void Step_5_Text_toEnterFumo()
    {
        if (Config.flag)
        {
            Debug.Log(Config.flag);
            gameObjects[2].transform.SetPositionAndRotation(positions[9].position, positions[9].rotation);
            //让用户点击墨刷拖曳
            camera.gameObject.transform.SetPositionAndRotation(positions[4].position, positions[4].rotation);
            tips[8].gameObject.SetActive(true);
            buttons[3].gameObject.SetActive(true);
            gameObjects[3].GetComponent<Typesetting>().enabled = true;
            Config.flag = false;

        } 
    }

    public void Step_5_Button_toExitFumo()
    {
        gameObjects[2].transform.SetPositionAndRotation(positions[7].position, positions[7].rotation);
        
        //用户点击完成按钮材质颜色加深  显示shuayin文本
        camera.gameObject.transform.SetPositionAndRotation(positions[0].position, positions[0].rotation);
        tips[8].gameObject.SetActive(false);
        tips[7].gameObject.SetActive(false);
        tips[9].gameObject.SetActive(true);
        gameObjects[3].GetComponent<Typesetting>().enabled = false;
        buttons[3].gameObject.SetActive(false);
        //播放动画让纸铺上
        //播放完成让提示文本出现“点击右侧刷子进行刷印”
        animator.speed = 1;
        animator.Play("Puzhi");
        

    }

    public void Step_6_Text_toEnterShua()
    {
        gameObjects[3].transform.SetPositionAndRotation(positions[10].position, positions[10].rotation);
        camera.gameObject.transform.SetPositionAndRotation(positions[5].position, positions[5].rotation);
        tips[10].gameObject.SetActive(true);
        buttons[4].gameObject.SetActive(true);
    }

    public void Step_6_Button_toExitShua()
    {
        gameObjects[3].transform.SetPositionAndRotation(positions[8].position, positions[8].rotation);
        tips[9].gameObject.SetActive(false);
        tips[10].gameObject.SetActive(false);
        buttons[4].gameObject.SetActive(false);
        //播放动画让纸反正面   到90°是添加事件让贴图附上去
        animator.Play("Puzhi2");
 
    }

    private void Update()
    {
        if (flag)
        {
            camera.transform.position = Vector3.MoveTowards(camera.transform.position, positions[6].position, 2 * Time.deltaTime);
            /*if (camera.gameObject.transform.position.x != positions[6].position.x
                || camera.gameObject.transform.position.y != positions[6].position.y)
            {
                
            }*/
        }
    }
}
