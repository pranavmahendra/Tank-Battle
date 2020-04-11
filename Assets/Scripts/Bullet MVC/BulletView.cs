using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank.bullet
{
    public class BulletView : MonoBehaviour
    {
        public BulletController bulletController;
        public BulletType bulletType;

        

        public void initialize(BulletController bulletController)
        {
            this.bulletController = bulletController;
        }


        private void Start()
        {
     
            //bullet type should be equal to that of tank.
            //Giving an error on pressing space.
            bulletType = bulletController.GetBulletModel().BulletType;

            Debug.Log("This is from Bullet View");
        }

        private void Update()
        {
            bulletMovement();
        }

        

        public void bulletMovement()
        {

            transform.Translate(Vector3.forward * 2f * Time.deltaTime);
        }

       
    }
}