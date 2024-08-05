using Manager;
using Player;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Enemy 
{
    public class CreateGhostMove : MonoBehaviour
    {
        private Status status;
        private GameManager manager;
        public GameObject Blocker;
        public Vector3 center = new Vector3(0,0,0);
        public float radius;
        private float x;
        private float y;
        private float z;
        private float theta = 0;
        private float phy = 0;
        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(EnemyAttack());
            status = GetComponent<Status>();
            manager = GetComponent<GameManager>();
        }

        void Update()
        {
            x = radius * Mathf.Sin(theta) * Mathf.Cos(phy);
            y = radius * Mathf.Sin(theta) + Mathf.Sin(phy);
            z = radius * Mathf.Cos(theta);
            transform.position = center + new Vector3(x, y, z) * radius;
            theta += (2f * Mathf.PI / 360);
            if (this.gameObject.transform.position.y <= -3)
            {
                KilledEnemy();
            }
            if (status.Hp <= 0)
            {
                KilledEnemy();
            }
        }

        private void KilledEnemy()
        {
            Destroy(this.gameObject);
            GameManager.KilledEnemy++;
            StopCoroutine(EnemyAttack());
            manager.SetKilledEnemy();
        }

        IEnumerator EnemyAttack()
        {
            while (true)
            {
                Instantiate(Blocker);
                yield return new WaitForSeconds(2);
            }
        }
    }
}

