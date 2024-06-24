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
        // Start is called before the first frame update
        void Start()
        {
            Player = GameObject.Find("Player");
            agent = GetComponent<NavMeshAgent>();
        }

        // Update is called once per frame
        void Update()
        {
            if (this.gameObject.transform.position.y <= -3)
            {
                Destroy(this.gameObject);
            }
            agent.destination = Player.transform.position;
        }
    }
}
