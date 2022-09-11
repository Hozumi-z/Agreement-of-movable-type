using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimatorController : MonoBehaviour
{
    public Animator animator;
    public GameObject paper;
    public Text tip;
    public void AnimationEvent()
    {
        paper.GetComponent<MeshRenderer>().material.mainTexture = Resources.Load("Final") as Texture2D;
        Vector3 localScale = paper.transform.localScale;
        Vector3 scale = new Vector3(localScale.x * -1, localScale.y, localScale.z);
        paper.transform.localScale = scale;
        GameObject.Find("Controller").GetComponent<Controller>().flag = true;
    }

    public void StopAnimation_1()
    {
        if (animator.GetFloat("Speed") == 1)
        {
            animator.speed = 0;
            tip.gameObject.SetActive(true);//“点击右侧刷子进行刷印
        }
    }

    public void StopAnimation_2()
    {
        if (animator.GetFloat("Speed") == 1)
        {
            animator.speed = 0;
            
        }
    }

}
