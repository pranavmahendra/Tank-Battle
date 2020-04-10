using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank.bullet
{
    public class BulletView : MonoBehaviour
    {
        public BulletController bulletController;
        public BulletType bulletType;

        private void Start()
        {
            bulletType = bulletController.GetBulletModel().BulletType;
        }

        private void Update()
        {

        }

        public void initialize(BulletController bulletController)
        {
            this.bulletController = bulletController;
        }

    }
}