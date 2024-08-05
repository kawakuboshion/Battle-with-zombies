using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagicCircleSetHp : MonoBehaviour,SetHp_var
{
    [SerializeField] Slider Hp_var;
    private Enemy.Status Status;

    void Start()
    {
        Status = GetComponent<Enemy.Status>();
        Hp_var.maxValue = Status.Hp;
        SetHp();
    }

    public void SetHp()
    {
        Hp_var.value = Status.Hp;
    }
}
