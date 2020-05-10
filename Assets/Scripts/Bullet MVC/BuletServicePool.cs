using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank.bullet
{
    public class BuletServicePool : ServicePool<BulletController>
    {

        private BulletModel bulletModel;
        private BulletView bulletView;
        private string layer { get; set; }



        protected override BulletController CreateItem()
        {


            BulletController bulletController = new BulletController(bulletModel, bulletView, layer);

            return bulletController;
        }



        public BulletController GetBullet(BulletModel bulletModel,BulletView bulletPrefab,string Layer)
        {
            this.bulletModel = bulletModel;
            this.bulletView = bulletPrefab;
            this.layer = Layer;
    

            return GetItem();
        }



        public override void ReturnItem(BulletController bulletController)
        {
            base.ReturnItem(bulletController);
            //bulletController.BulletView.gameObject.layer = 0;
        }


    }

}
