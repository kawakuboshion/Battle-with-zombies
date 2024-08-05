using Manager;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowResult : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI Time_Text;
    [SerializeField] TextMeshProUGUI HP_Text;
    [SerializeField] TextMeshProUGUI KilledEneny_Text;
    [SerializeField] TextMeshProUGUI Score_Text;
    // Start is called before the first frame update
    void Start()
    {
        GameManager gamemanager = GetComponent<GameManager>();
        int CastedLimitTime = (int)GameManager.LimitTime;
        Time_Text.text = "残った時間: " + CastedLimitTime;
        HP_Text.text = "残ったHP: " + Player.Status.Hp;
        KilledEneny_Text.text = "倒した敵の数: " + GameManager.KilledEnemy;
        int Score = (int)GameManager.LimitTime * 100 + (int)Player.Status.Hp * 200 + GameManager.KilledEnemy * 300;
        Score_Text.text = "スコア: " + Score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
