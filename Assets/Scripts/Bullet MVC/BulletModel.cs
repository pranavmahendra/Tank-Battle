using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank.bullet
{
    public class BulletModel
    {

        public BulletModel(BulletScriptableObject bulletScriptableObject)
        {
            BulletType = bulletScriptableObject.bulletType;
            Damage = (int)bulletScriptableObject.damage;
        }

        public BulletType BulletType { get; }
        public int Damage { get; }


        public void DestroyBulletModel(BulletModel bulletModel)
        {
            bulletModel = null;
        }

    }



}
