using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using BattleTank.Tank;

namespace BattleTank.bullet
{
    public class BulletService : MonosingletonGeneric<BulletService>
    {
        private BulletModel bulletModel;
        private BulletController bulletController;
        public BulletView bulletView;

        public event Action<TankView> onBulletFire;

        public BulletScriptableObjectList bulletList;
        private BulletScriptableObject bulletScriptableObject;


        private void Start()
        {

            bulletScriptableObject = ScriptableObject.CreateInstance<BulletScriptableObject>();
            Debug.Log("This message is from bullet service.");

            //Debug.Log("The bullet being created is " + CreateNewBullet(1).BulletModel.BulletType);

        }

        public BulletController CreateNewBullet(int index)
        {
            bulletScriptableObject = bulletList.bullets[index];
            bulletModel = new BulletModel(bulletScriptableObject);

            bulletController = new BulletController(bulletModel,bulletView);

            //Involoking bullet event with tank view arg.
            for (int i = 0; i < TankService.Instance.tankLists.Count; i++)
            {
                onBulletFire?.Invoke(TankService.Instance.tankLists[i].TankView);
            }

            return bulletController;
        }

        public void DestroyBullet(BulletController bulletController)
        {
            bulletController.bulletDestroy();
        }

    }

}
