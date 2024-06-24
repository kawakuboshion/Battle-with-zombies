using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    GameObject targetObj;
    public float mouseXSpeed;
    public float mouseYSpeed;
    Vector3 targetPos;
    Vector3 angle;
    Vector3 primary_angle;
    void Start()
    {
        targetObj = GameObject.Find("Player");
        targetPos = targetObj.transform.position;
        angle = this.gameObject.transform.localEulerAngles;
        primary_angle = this.gameObject.transform.localEulerAngles;
    }

    void Update()
    {
        // targetの移動量分、自分（カメラ）も移動する
        transform.position += targetObj.transform.position - targetPos;
        targetPos = targetObj.transform.position;
        // 回転制限
        angle.x -= Input.GetAxis("Mouse Y");
        if (angle.x <= primary_angle.x - 20f)
        {
            angle.x = primary_angle.x - 20f;
        }
        if (angle.x >= primary_angle.x + 20f)
        {
            angle.x = primary_angle.x + 20f;
        }
        // マウスの移動量
        float mouseInputX = Input.GetAxis("Mouse X");
        // targetの位置のY軸を中心に、回転（公転）する
        transform.RotateAround(targetPos, Vector3.up,mouseInputX * Time.deltaTime * mouseXSpeed);
        
        // カメラの垂直移動
        transform.RotateAround(this.transform.position, transform.right, angle.x * Time.deltaTime * mouseYSpeed);
        this.gameObject.transform.localEulerAngles = angle;
    }
}
