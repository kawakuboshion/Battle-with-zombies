using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSystem
{
    public class CreateEnemy : MonoBehaviour
    {
        public GameObject Enemy;
        public GameObject Player;
        public float x = 0;
        public float y = 0;
        public float z = 0;
        public float theta = 0;
        public Vector3 center;
        public int spawnWaitTime = 0;
        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(spawnEnemy());
        }

        // Update is called once per frame
        void Update()
        {

        }

        private IEnumerator spawnEnemy()
        {
            center = Player.transform.position;
            x = Mathf.Sin(theta);
            z = Mathf.Cos(theta);
            yield return new WaitForSeconds(spawnWaitTime * 0.1f);
            Instantiate(Enemy, center + new Vector3(x * Random.Range(2, 10), 0.1f, z * Random.Range(2, 10)), Quaternion.identity);
            theta += (2f * Mathf.PI / 360) * 5f;
        }
    }
}
