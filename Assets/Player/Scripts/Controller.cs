using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class Controller : MonoBehaviour
    {
        float inputHorizontal;
        float inputVertical;
        Rigidbody rb;
        Animator animator;

        public float moveSpeed = 10f;
        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody>();
            animator = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            inputHorizontal = Input.GetAxisRaw("Horizontal");
            inputVertical = Input.GetAxisRaw("Vertical");
            if (inputHorizontal != 0 || inputVertical != 0)
            {
                animator.SetFloat("Speed", 1f);
            }
            else
            {
                animator.SetFloat("Speed", 0f);
            }
        }

        void FixedUpdate()
        {
            // �J�����̕�������AX-Z���ʂ̒P�ʃx�N�g�����擾
            Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;

            // �����L�[�̓��͒l�ƃJ�����̌�������A�ړ�����������
            Vector3 moveForward = cameraForward * inputVertical + Camera.main.transform.right * inputHorizontal;
            // �ړ������ɃX�s�[�h���|����B�W�����v�◎��������ꍇ�́A�ʓrY�������̑��x�x�N�g���𑫂��B
            rb.velocity = moveForward * moveSpeed + new Vector3(0, 0, 0);
            // �L�����N�^�[�̌�����i�s������
            if (moveForward != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(moveForward);
            }
        }
    }
}
