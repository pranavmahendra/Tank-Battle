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

        private BuletServicePool BuletServicePool;

        public BulletScriptableObjectList bulletList;
        private BulletScriptableObject bulletScriptableObject;

        public event Action onBulletCreated;
        public event Action onBulletDestroy;

        public List<BulletController> bulletsCreated = new List<BulletController>();

        

        private void Start()
        {

            bulletScriptableObject = ScriptableObject.CreateInstance<BulletScriptableObject>();
            //Debug.Log("This message is from bullet service.");

            BuletServicePool = GetComponent<BuletServicePool>();

           

            //Debug.Log("The bullet being created is " + CreateNewBullet(1).BulletModel.BulletType);

        }


        public BulletController CreateBullet(int index,string Layer)
        {
            bulletScriptableObject = bulletList.bullets[index];

            bulletModel = new BulletModel(bulletScriptableObject);

            //bulletController = new BulletController(bulletModel, bulletView,Layer);
            bulletController = BuletServicePool.GetBullet(bulletModel, bulletView,Layer);

            bulletController.BulletView.EnableView();


            bulletsCreated.Add(bulletController);


            onBulletCreated?.Invoke();

            //Initialize bulletview from health
            HealthBar.Instance.followBullet();


            return bulletController;

        }


        public void DestroyBullet(BulletController bulletController)
        {
            //event Invoke
            onBulletDestroy?.Invoke();
            //Play VFX.
            bulletExplode(bulletController);
            //Disable Logic
            bulletController.BulletView.DisableViewOnCollision();
            //Return Item
            BuletServicePool.ReturnItem(bulletController);
  
        }

        public void DestroyRandom(BulletController bulletController)
        {
           
                onBulletDestroy?.Invoke();
                bulletExplode(bulletController);
                bulletController.BulletView.DisableRandom();
                BuletServicePool.ReturnItem(bulletController);

        }

        //Explosion
        public void bulletExplode(BulletController bulletController)
        {
            VFXService.Instance.CreateBulletExplosion(bulletController.BulletView.transform.position, bulletController.BulletView.transform.rotation);
        }

  
    }

}
