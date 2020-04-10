using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank.bullet
{
    public class BulletModel
    {
        public BulletModel(BulletType bulletType, int speed, int damage)
        {
            BulletType = bulletType;
            Speed = speed;
            Damage = damage;
        }

        public BulletType BulletType { get; }
        public int Speed { get; }
        public int Damage { get; }
    }

}
