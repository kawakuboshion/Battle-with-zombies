using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Player
{
    public class Attack : MonoBehaviour
    {
        [SerializeField] GameObject Weapon;
        Rigidbody Rigidbody;
        // Start is called before the first frame update
        void Start()
        {
            Rigidbody = Weapon.GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
                Instantiate(Weapon,cameraForward, Quaternion.identity);
                Rigidbody.velocity = cameraForward + new Vector3(1,0,1);
            }
        }

    }
}

