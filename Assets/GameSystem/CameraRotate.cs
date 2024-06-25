using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    GameObject targetObj;
    public float mouseXSpeed = 1;
    public float mouseYSpeed = 1;
    public float rotationLimitX = 0;
    public float rotationLimitY = 0;
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
        angle.y += Input.GetAxis("Mouse X");
        if (angle.y <= primary_angle.y - rotationLimitX)
        {
            angle.y = primary_angle.y - rotationLimitX;
        }
        if (angle.y >= primary_angle.y + rotationLimitX)
        {
            angle.y = primary_angle.y + rotationLimitX;
        }
        angle.x -= Input.GetAxis("Mouse Y");
        if (angle.x <= primary_angle.x - rotationLimitY)
        {
            angle.x = primary_angle.x - rotationLimitY;
        }
        if (angle.x >= primary_angle.x + rotationLimitY)
        {
            angle.x = primary_angle.x + rotationLimitY;
        }
        // targetの位置のY軸を中心に、回転（公転）する
        this.transform.transform.localRotation = new Quaternion(0, angle.y * Time.deltaTime * mouseXSpeed, 0,0);
        
        // カメラの垂直移動
        transform.RotateAround(this.transform.position, transform.right, angle.x * Time.deltaTime * mouseYSpeed);
        this.gameObject.transform.localEulerAngles = angle;
    }
}
