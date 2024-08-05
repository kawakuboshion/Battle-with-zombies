using Player;
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
        public GameObject CreateEnemy;
        public GameObject Player;
        public TextMeshProUGUI Time_text;
        public TextMeshProUGUI KilledEnemy_text;
        private float x = 0;
        private float z = 0;
        private float theta = 0;
        private int CastedLimitTime = 0;
        private Status PlayerStatus;
        public Vector3 center;
        public int spawnWaitTime = 0;
        public static float LimitTime = 100;
        public static int KilledEnemy = 0;
        private bool IsHarf = true;
        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(spawnEnemy());
            SetKilledEnemy();
            Time_text.text = LimitTime.ToString();
            PlayerStatus = Player.GetComponent<Status>();
        }

        // Update is called once per frame
        void Update()
        {
            LimitTime -= Time.deltaTime;
            CastedLimitTime = (int)LimitTime;
            Time_text.text = CastedLimitTime.ToString();
            if(LimitTime <= 50 && IsHarf)
            {
                StartCoroutine(spawnCreateEnemy());
                IsHarf = false;
            }
            if(LimitTime <= 0 || Status.Hp <= 0)
            {
                StopAllCoroutines();
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

        private IEnumerator spawnCreateEnemy()
        {
            for(; LimitTime >= 0;)
            {
                Instantiate(CreateEnemy,new Vector3(0,0,0), Quaternion.identity);
                yield return new WaitForSeconds(spawnWaitTime);
            }
        }

        public void SetKilledEnemy()
        {
            KilledEnemy_text.text = "�|�����G�̐�:" + KilledEnemy;
        }
    }
}