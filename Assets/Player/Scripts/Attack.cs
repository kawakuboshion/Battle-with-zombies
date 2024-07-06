using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Player
{
    public class Attack : MonoBehaviour
    {
        [SerializeField] GameObject Weapon;
        GameObject Player;
        Rigidbody Rigidbody;
        public float power = 100;
        // Start is called before the first frame update
        void Start()
        {
            Player = this.gameObject;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 1, 1)).normalized;
                GameObject heal = Instantiate(Weapon, cameraForward * 2 + Player.transform.position + new Vector3(0, 3, 0), Quaternion.identity);
                Rigidbody = heal.GetComponent<Rigidbody>();
                Rigidbody.velocity = cameraForward * power;
            }
        }

    }
}

