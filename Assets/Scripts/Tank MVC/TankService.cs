﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BattleTank.bullet;


namespace BattleTank.Tank
{
    public class TankService : MonosingletonGeneric<TankService>
    {

        private TankController tankController;
        private TankModel _tankModel;
        public TankView _tankView;

        private TankScriptableObjects _tankScriptableObject;
        public TankScriptableObjectList _tankScriptableObjectList;

        public BulletService _bulletService;

        public int combinationCreation;

      
        private void Start()
        {
            _bulletService = BulletService.Instance;
            _tankScriptableObject = ScriptableObject.CreateInstance<TankScriptableObjects>();
            
  
            Debug.Log(CreateNewTank().TankModel.TankType + " Tank is created.");
            Debug.Log(_bulletService.CreateNewBullet(combinationCreation).BulletModel.BulletType + " This bullet is fired from Tank Service.");


        }


       public TankController CreateNewTank()
        {
            //tankScriptableObject = tankScriptableObjectList.tanks[Random.Range(0,3)];
            //Extract number from tankObjectlist and apply that value as TSO.

            _tankScriptableObject = _tankScriptableObjectList.tanks[combinationCreation];
            _tankModel = new TankModel(_tankScriptableObject);


            //initialize the value of TC.
            tankController = new TankController(_tankModel, _tankView);

            return tankController;
        }

    }
}

