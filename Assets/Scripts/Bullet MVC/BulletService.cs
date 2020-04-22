﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank.bullet
{
    public class BulletService : MonosingletonGeneric<BulletService>
    {
        private BulletModel bulletModel;
        private BulletController bulletController;
        public BulletView bulletView;


        public BulletScriptableObjectList bulletList;
        private BulletScriptableObject bulletScriptableObject;


        private void Start()
        {

            bulletScriptableObject = ScriptableObject.CreateInstance<BulletScriptableObject>();
            Debug.Log("This message is from bullet service.");



            //Debug.Log("The bullet being created is " + CreateNewBullet(1).BulletModel.BulletType);

        }

        public BulletController CreateNewBullet(Vector3 bulletSpawnPosition,Quaternion bulletSpawnRotation,int index)
        {
            bulletScriptableObject = bulletList.bullets[index];
            bulletModel = new BulletModel(bulletScriptableObject);

            bulletController = new BulletController(bulletModel,bulletView);

            bulletView.transform.position = bulletSpawnPosition;
            bulletView.transform.rotation = bulletSpawnRotation;

            return bulletController;
        }



    }

}
