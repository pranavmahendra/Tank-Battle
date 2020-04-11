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

            BulletView.initialize(this);
        }

        public BulletModel BulletModel { get; }
        public BulletView BulletView { get; }
        public BulletScriptableObjectList BulletScriptableObjectList;

        public BulletModel GetBulletModel()
        {
            return BulletModel;
        }

       

    }
}

