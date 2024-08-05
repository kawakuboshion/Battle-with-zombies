using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    public class Status : MonoBehaviour,SetHp_var
    {
        public float Hp_Max;
        public static float Hp;
        public float Power = 10;
        [SerializeField] Slider Hp_ver;
        // Start is called before the first frame update
        void Start()
        {
            Hp_ver.maxValue = Hp_Max;
            Hp = Hp_Max;
            Hp_ver.value = Hp;
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void SetHp()
        {
            Hp_ver.value = Hp;
        }
    }
}
