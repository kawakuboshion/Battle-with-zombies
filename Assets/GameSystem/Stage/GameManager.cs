using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Manager
{
    public class GameManager : MonoBehaviour
    {
        public GameObject Enemy;
        public GameObject Player;
        public TextMeshProUGUI Time_text;
        public TextMeshProUGUI KilledEnemy_text;
        private float x = 0;
        private float z = 0;
        private float theta = 0;
        private int CastedLimitTime = 0;
        public Vector3 center;
        public int spawnWaitTime = 0;
        public float LimitTime = 300;
        public int KilledEnemy = 0;
        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(spawnEnemy());
            SetKilledEnemy();
            Time_text.text = LimitTime.ToString();
        }

        // Update is called once per frame
        void Update()
        {
            LimitTime -= Time.deltaTime;
            CastedLimitTime = (int)LimitTime;
            Time_text.text = CastedLimitTime.ToString();
            if(LimitTime < 0)
            {
                SceneManager.LoadScene("Result");
            }
        }
        private IEnumerator spawnEnemy()
        {
            for (; LimitTime >= 0;)
            {
                yield return new WaitForSeconds(spawnWaitTime);
                center = Player.transform.position;
                x = Mathf.Sin(theta);
                z = Mathf.Cos(theta);
                Instantiate(Enemy, center + new Vector3(x * Random.Range(2, 10), 0.1f, z * Random.Range(2, 10)), Quaternion.identity);
                theta += (2f * Mathf.PI / 360) * 5f;
            }
        }

        public void SetKilledEnemy()
        {
            KilledEnemy_text.text = "ì|ÇµÇΩìGÇÃêî:" + KilledEnemy;
        }
    }
}