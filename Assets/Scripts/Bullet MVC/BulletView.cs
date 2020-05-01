using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank.bullet
{
    public class BulletView : MonoBehaviour
    {
        public BulletController bulletController;
  

        private void Start()
        {
            
            Debug.Log("This is from Bullet View");
        }

        private void Update()
        {
            bulletMovement();
            bulletController.randomBulletsDestroy();
         
        }

        //Linking view and controller.
        public void Initialize(BulletController controller, string Layer)
        {
            this.bulletController = controller;
            this.gameObject.layer = LayerMask.NameToLayer(Layer);
            
        }

        //Bullet movement.
        public void bulletMovement()
        {

            transform.Translate(Vector3.forward * 10f * Time.deltaTime);
        }


        //Damage
        //If fired by player, collision between bullet and enemey.
        //If fired by enemey, collision between bullet and player.
        private void OnCollisionEnter(Collision collision)
        {
            IDamagable damagable = collision.gameObject.GetComponent<IDamagable>();
            if (damagable != null)
            {

                damagable.TakeDamage(bulletController.GetBulletModel().BulletType, bulletController.GetBulletModel().Damage);
                //Destroy Bullet
                //BulletService.Instance.DestroyBullet(this.bulletController);
                Destroy(gameObject);
                BulletService.Instance.DestroyBullet(bulletController);
            }
        }

        //Destroy BulletView.
        public void DestroyBulletView(BulletView bulletviewDes)
        {
            Destroy(bulletviewDes.gameObject, 2f);
            bulletviewDes = null;
        }
    }
}