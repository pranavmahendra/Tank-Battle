using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BattleTank.bullet;


namespace BattleTank.Tank
{
    public class TankService : MonosingletonGeneric<TankService>
    {

        //This is Singleton class.

        public TankView tankView;

        public TankScriptableObjectList tankList;

        public  BulletService bulletService;


        private void Start()
        {
            Debug.Log("This message is from Tank Service");
            

            for (int i=0; i < 3; i++)
            {
                CreateNewTank(i);
                
            }
                 
        }
      
        //Method for creating new TC. This is returning
        //TankController.
        public  TankController CreateNewTank(int index)
        {

            TankScriptableObjects tankScriptableObject = tankList.tanks[index];
            Debug.Log("Created type of tank is" + tankScriptableObject.TankType);

            //Created a first tank model, and prefab is the 3d model(prefab)
            //with which this TankView script is attached to.
            TankModel tankModel1 = new TankModel(tankScriptableObject);


            //Created a new tankcontroller which is using reference of tankModel(Script) 
            //and Prefab with TankView attached.
            TankController tankcontroller1 = new TankController(tankModel1, tankView);


            return tankcontroller1;
        }

       
       
    }
}

