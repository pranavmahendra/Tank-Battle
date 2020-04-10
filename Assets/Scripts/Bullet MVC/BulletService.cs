using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank.bullet
{
    public class BulletService : MonosingletonGeneric<BulletService>
    {
        public BulletView bulletView;
        public BulletModel bulletModel;

        public BulletScriptableObjectList bulletList;

        private void Start()
        {
            Debug.Log("This message is from bullet service.");

            for(int i = 0; i < 3; i++)
            {
                CreateNewBullet(i);
            }

        }

        public BulletController CreateNewBullet(int index)
        {
            BulletScriptableObject bulletScriptableObject = bulletList.bullets[index];
            BulletModel bulletModel = new BulletModel(bulletScriptableObject);

            BulletController bulletController = new BulletController(bulletModel, bulletView);


            return bulletController;
        }

    }


}
