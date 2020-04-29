using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using BattleTank.EnemyTank;
using System;


namespace BattleTank.Tank
{
    public class TankView : MonoBehaviour 
    {
        public event Action onBulletFire;

        public TankController tankController;
     

        public Transform barrelTip;
        public LayerMask rayMask;

        public Material tankColor;

        public ParticleSystem particle;



        private void Start()
        {
            
            Debug.Log("This tank view is of " + tankController.TankModel.TankType);
            changeColor();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                tankController.tankFire();
                onBulletFire?.Invoke();
            }

            tankController.movement();

            tankController.mouseRotation();

            
        }

        //Initialization Method.
        public void initialize(TankController tankController)
        {
            this.tankController = tankController;
            
        }


        //Collision with enemy tank.
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.GetComponent<EnemyView>() != null)
            {
                SceneService.Instance.sceneRestart();

            }
        }

        private void changeColor()
        {
            tankColor.SetColor("_Color", tankController.TankModel.colorType);
        }
        


    }
}
