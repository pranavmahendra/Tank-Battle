using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank.bullet
{
    public class BulletController
    {
        public BulletController(BulletModel bulletModel, BulletView bulletPrefab)
        {
            BulletModel = bulletModel;

            BulletView = GameObject.Instantiate<BulletView>(bulletPrefab);

            BulletView.Initialize(this);
        }

        public BulletModel BulletModel { get; }
        public BulletView BulletView { get; }
       

        public BulletModel GetBulletModel()
        {
            return BulletModel;
        }


    }

}

