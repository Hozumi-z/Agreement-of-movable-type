using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Typesetting : MonoBehaviour
{
    private Vector3 _vec3TargetScreenSpace;// 目标物体的屏幕空间坐标  
    private Vector3 _vec3TargetWorldSpace;// 目标物体的世界空间坐标  
    private Transform _trans;// 目标物体的空间变换组件  
    private Vector3 _vec3MouseScreenSpace;// 鼠标的屏幕空间坐标  
    private Vector3 _vec3Offset;// 偏移 

    void Awake() { _trans = transform; }

    public void Start()
    {
        //StopCoroutine("OnMouseDown");

    }
    IEnumerator OnMouseDown()

    {

        // 把目标物体的世界空间坐标转换到它自身的屏幕空间坐标   

        _vec3TargetScreenSpace = Camera.main.WorldToScreenPoint(_trans.position);

        // 存储鼠标的屏幕空间坐标（Z值使用目标物体的屏幕空间坐标）   

        _vec3MouseScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _vec3TargetScreenSpace.z);

        // 计算目标物体与鼠标物体在世界空间中的偏移量   

        _vec3Offset = _trans.position - Camera.main.ScreenToWorldPoint(_vec3MouseScreenSpace);

        // 鼠标左键按下   

        while (Input.GetMouseButton(0))
        {

            // 存储鼠标的屏幕空间坐标（Z值使用目标物体的屏幕空间坐标）  

            _vec3MouseScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _vec3TargetScreenSpace.z);

            // 把鼠标的屏幕空间坐标转换到世界空间坐标（Z值使用目标物体的屏幕空间坐标），加上偏移量，以此作为目标物体的世界空间坐标  

            _vec3TargetWorldSpace = Camera.main.ScreenToWorldPoint(_vec3MouseScreenSpace) + _vec3Offset;

            // 更新目标物体的世界空间坐标   

            _trans.position = _vec3TargetWorldSpace;

            // 等待固定更新   

            yield return new WaitForFixedUpdate();
        }
    }
    public void OnTriggerEnter(Collider others)
    {
        var pos = others.gameObject;

        transform.SetPositionAndRotation(pos.transform.position, pos.transform.rotation);
        transform.SetParent(GameObject.Find("版").transform);
        others.gameObject.SetActive(false);
        gameObject.GetComponent<TSID>().ID = others.gameObject.GetComponent<TSID>().ID;
        gameObject.GetComponent<BoxCollider>().enabled = false;
        gameObject.GetComponent<Typesetting>().enabled = false;

        StopCoroutine("OnMouseDown");

    }
}
