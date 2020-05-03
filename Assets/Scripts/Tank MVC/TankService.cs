using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using BattleTank.bullet;
using BattleTank.EnemyTank;


namespace BattleTank.Tank
{
    
    public class TankService : MonosingletonGeneric<TankService>
    {

        public TankController tankController;
        private TankModel tankModel;
        public TankView tankView;

        public List<TankController> tankLists = new List<TankController>();

        private TankScriptableObjects tankScriptableObject;
        public TankScriptableObjectList tankScriptableObjectList;

        //public event Action onBulletHit;
        public event Action onBulletFire;
        public event Action onDamageTaken;
        public event Action onDeathofPlayer;

        public int combinationCreation;

      


        private void Start()
        {
      
            tankScriptableObject = ScriptableObject.CreateInstance<TankScriptableObjects>();

            //combinationCreation = UnityEngine.Random.Range(1,3);
            combinationCreation = 3;

            //Added tank to the list.
            CreateNewTank(combinationCreation);

            //Service initilization methods.
            SceneService.Instance.followPlayer();
            CameraFollow.Instance.followPlayerCamera();
            HealthBar.Instance.followHealthPlayer();
          


            Debug.Log("MyID is " + tankLists[0].TankModel.myID);
            //Debug.Log(tankLists.Count);
            //Debug.Log("The tank type is " + tankLists[0].getModel().TankType);

        }

        public TankController CreateNewTank(int combination)
        {
            //tankScriptableObject = tankScriptableObjectList.tanks[Random.Range(0,3)];
            //Extract number from tankObjectlist and apply that value as TSO.
            this.combinationCreation = combination;
            

            tankScriptableObject = tankScriptableObjectList.tanks[combination];
            tankModel = new TankModel(tankScriptableObject);


            //initialize the value of TC.
            tankController = new TankController(tankModel, tankView);
            tankLists.Add(tankController);
            return tankController;
   
        }

        public void damageEvenet()
        {
            onDamageTaken?.Invoke();
        }

        public void fireEvent()
        {
            onBulletFire?.Invoke();
        }

        public void playerDeadEvent()
        {
            onDeathofPlayer?.Invoke();
        }

    }
}


