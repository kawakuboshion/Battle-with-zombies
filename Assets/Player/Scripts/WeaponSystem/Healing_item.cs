using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
            Destroy(this.gameObject, 1f);
        }


        private void OnTriggerEnter(Collider other)
        {
            Enemy.Status status = other.gameObject.GetOrAddComponent<Enemy.Status>();
            status.Hp -= PlayerStatus.Power;
        }
    }
}

