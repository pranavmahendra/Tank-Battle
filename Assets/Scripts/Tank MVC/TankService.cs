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

        public event Action onBulletHit;

        public int combinationCreation;
<<<<<<< HEAD

      
=======
>>>>>>> d7803cc80e09d01199f4b8f3ecdaae8d60e5f754


        private void Start()
        {
      
            tankScriptableObject = ScriptableObject.CreateInstance<TankScriptableObjects>();

<<<<<<< HEAD
            combinationCreation = 3;

            //Added tank to the list.
            CreateNewTank(combinationCreation);
=======
            //Added tank to the list.
            
            CreateNewTank(3);
>>>>>>> d7803cc80e09d01199f4b8f3ecdaae8d60e5f754

            //Service initilization methods.
            SceneService.Instance.followPlayer();
            CameraFollow.Instance.followPlayerCamera();
            EnemyService.Instance.followPlayerEnemeyState();

            Debug.Log(tankLists.Count);
            Debug.Log("The tank type is " + tankLists[0].getModel().TankType);

        }

        public TankController CreateNewTank(int combination)
        {
            //tankScriptableObject = tankScriptableObjectList.tanks[Random.Range(0,3)];
            //Extract number from tankObjectlist and apply that value as TSO.
            this.combinationCreation = combination;
<<<<<<< HEAD
            
=======
>>>>>>> d7803cc80e09d01199f4b8f3ecdaae8d60e5f754

            tankScriptableObject = tankScriptableObjectList.tanks[combination];
            tankModel = new TankModel(tankScriptableObject);


            //initialize the value of TC.
            tankController = new TankController(tankModel, tankView);
            tankLists.Add(tankController);
            return tankController;
   
        }
    }
}


