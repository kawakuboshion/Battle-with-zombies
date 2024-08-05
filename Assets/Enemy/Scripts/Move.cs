using Manager;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
    public class Move : MonoBehaviour
    {
        private GameObject Player;
        private NavMeshAgent agent;
        private Status status;
        private GameManager manager;
        // Start is called before the first frame update
        void Start()
        {
            Player = GameObject.Find("Player");
            agent = GetComponent<NavMeshAgent>();
            status = GetComponent<Status>();
            manager = FindObjectOfType<GameManager>();
        }

        // Update is called once per frame
        void Update()
        {
            if (this.gameObject.transform.position.y <= -3)
            {
                KilledEnemy();
            }
            agent.destination = Player.transform.position;
            if(status.Hp <= 0)
            {
                KilledEnemy();
            }
        }

        private void KilledEnemy()
        {
            Destroy(this.gameObject);
            GameManager.KilledEnemy++;
            manager.SetKilledEnemy();
        }
    }
}
