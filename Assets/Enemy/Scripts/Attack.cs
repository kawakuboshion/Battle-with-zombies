using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemy;
using Player;
using Unity.VisualScripting;

namespace Enemy
{
    public class Attack : MonoBehaviour
    {
        Status EnemyStatus;
        // Start is called before the first frame update
        void Start()
        {
            EnemyStatus = GetComponent<Status>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.tag == "Player")
            {
                StartCoroutine(EnemyAttack(other));
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                StopCoroutine(EnemyAttack(other));
            }
        }
        IEnumerator EnemyAttack(Collider other)
        {
            while (true)
            {
                yield return new WaitForSeconds(2);
                Player.Status status = other.gameObject.GetOrAddComponent<Player.Status>();
                status.Hp -= EnemyStatus.Power;
                status.SetHp_var();
            }
        }
    }
}
