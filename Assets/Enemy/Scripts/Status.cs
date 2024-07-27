using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy 
{
    public class Status : MonoBehaviour,IDamagable
    {
        public float Hp;
        public float Power;

        public void AddDamage(float Damage)
        {
            Hp -= Damage;
        }
    }
}

