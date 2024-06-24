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
        // target�̈ړ��ʕ��A�����i�J�����j���ړ�����
        transform.position += targetObj.transform.position - targetPos;
        targetPos = targetObj.transform.position;
        // ��]����
        angle.x -= Input.GetAxis("Mouse Y");
        if (angle.x <= primary_angle.x - 20f)
        {
            angle.x = primary_angle.x - 20f;
        }
        if (angle.x >= primary_angle.x + 20f)
        {
            angle.x = primary_angle.x + 20f;
        }
        // �}�E�X�̈ړ���
        float mouseInputX = Input.GetAxis("Mouse X");
        // target�̈ʒu��Y���𒆐S�ɁA��]�i���]�j����
        transform.RotateAround(targetPos, Vector3.up,mouseInputX * Time.deltaTime * mouseXSpeed);
        
        // �J�����̐����ړ�
        transform.RotateAround(this.transform.position, transform.right, angle.x * Time.deltaTime * mouseYSpeed);
        this.gameObject.transform.localEulerAngles = angle;
    }
}
