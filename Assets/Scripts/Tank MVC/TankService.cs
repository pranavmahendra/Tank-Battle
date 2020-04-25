using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using BattleTank.bullet;


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

     

        //public int combinationCreation;


        private void Start()
        {
      
            tankScriptableObject = ScriptableObject.CreateInstance<TankScriptableObjects>();

            //Added tank to the list.

            CreateNewTank(3);

            //Service initilization methods.
            SceneService.Instance.followPlayer();
            CameraFollow.Instance.followPlayerCamera();

            Debug.Log(tankLists.Count);
            Debug.Log("The tank type is " + tankLists[0].getModel().TankType);

        }

        public TankController CreateNewTank(int combination)
        {
            //tankScriptableObject = tankScriptableObjectList.tanks[Random.Range(0,3)];
            //Extract number from tankObjectlist and apply that value as TSO.


            tankScriptableObject = tankScriptableObjectList.tanks[combination];
            tankModel = new TankModel(tankScriptableObject);


            //initialize the value of TC.
            tankController = new TankController(tankModel, tankView);
            tankLists.Add(tankController);
            return tankController;
   
        }
    }
}


