using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

namespace Player
{
    public class Healing_item : MonoBehaviour
    {
        Status PlayerStatus;
        GameObject Player;
        // Start is called before the first frame update
        void Start()
        {
            Player = GameObject.Find("Player");
            PlayerStatus = Player.GetComponent<Status>();
        }

        // Update is called once per frame
        void Update()
        {
            Destroy(this.gameObject, 3f);
        }


        private void OnTriggerEnter(Collider other)
        {
            var target = other.GetComponent<IDamagable>();
            if (target != null)
            {
                target.AddDamage(PlayerStatus.Power);
            }
            var setHp = other.GetComponent <SetHp_var>();
            if (setHp != null)
            {
                setHp.SetHp();
            }
            Destroy(this.gameObject);
        }
    }
}

