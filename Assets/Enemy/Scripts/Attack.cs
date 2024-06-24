using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemy;

namespace Enemy
{
    public class Attack : MonoBehaviour
    {
        Status Status;
        // Start is called before the first frame update
        void Start()
        {
            Status = GetComponent<Status>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.tag == "Player")
            {
                
            }
        }
    }
}
