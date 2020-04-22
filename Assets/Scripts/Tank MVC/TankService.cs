using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BattleTank.bullet;


namespace BattleTank.Tank
{
    public class TankService : MonosingletonGeneric<TankService>
    {

        private TankController tankController;
        private TankModel tankModel;
        public TankView tankView;

        private TankScriptableObjects tankScriptableObject;
        public TankScriptableObjectList _tankScriptableObjectList;

        public BulletService bulletService;

        public int combinationCreation;

      
        private void Start()
        {
            bulletService = BulletService.Instance;
            tankScriptableObject = ScriptableObject.CreateInstance<TankScriptableObjects>();
            
  
            Debug.Log(CreateNewTank().TankModel.TankType + " Tank is created.");
            //Debug.Log(_bulletService.CreateNewBullet(combinationCreation).BulletModel.BulletType + " This bullet is fired from Tank Service.");


        }


       public TankController CreateNewTank()
        {
            //tankScriptableObject = tankScriptableObjectList.tanks[Random.Range(0,3)];
            //Extract number from tankObjectlist and apply that value as TSO.

            tankScriptableObject = _tankScriptableObjectList.tanks[combinationCreation];
            tankModel = new TankModel(tankScriptableObject);


            //initialize the value of TC.
            tankController = new TankController(tankModel, tankView);

            return tankController;
        }

    }
}

