using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank.bullet
{
    public class BulletService : MonosingletonGeneric<BulletService>
    {
        private BulletModel _bulletModel;
        private BulletController _bulletController;
        public BulletView _bulletView;


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
            _bulletModel = new BulletModel(bulletScriptableObject);

            _bulletController = new BulletController(_bulletModel,_bulletView);

            return _bulletController;
        }



    }

}
