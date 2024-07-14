using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject Player;
    private float x = 0;
    private float z = 0;
    private float theta = 0;
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
        for (; ; )
        {
            yield return new WaitForSeconds(spawnWaitTime);
            center = Player.transform.position;
            x = Mathf.Sin(theta);
            z = Mathf.Cos(theta);
            Instantiate(Enemy, center + new Vector3(x * Random.Range(2, 10), 0.1f, z * Random.Range(2, 10)), Quaternion.identity);
            theta += (2f * Mathf.PI / 360) * 5f;
        }
    }
}
