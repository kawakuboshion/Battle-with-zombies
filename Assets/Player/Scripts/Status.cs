using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    public class Status : MonoBehaviour
    {
        public float Hp_Max;
        public float Hp;
        [SerializeField] Slider Hp_ver;
        // Start is called before the first frame update
        void Start()
        {
            Hp_ver.maxValue = Hp_Max;
            Hp_ver.value = Hp;
            Hp = Hp_Max;
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void SetHp_var()
        {
            Hp_ver.value = Hp;
        }
    }
}
