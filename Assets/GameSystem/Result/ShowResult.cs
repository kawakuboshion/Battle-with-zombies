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
        Time_Text.text = "�c��������: " + CastedLimitTime;
        HP_Text.text = "�c����HP: " + Player.Status.Hp;
        KilledEneny_Text.text = "�|�����G�̐�: " + GameManager.KilledEnemy;
        int Score = (int)GameManager.LimitTime * 100 + (int)Player.Status.Hp * 200 + GameManager.KilledEnemy * 300;
        Score_Text.text = "�X�R�A: " + Score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
