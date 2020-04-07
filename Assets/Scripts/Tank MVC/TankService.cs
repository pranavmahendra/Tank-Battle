using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank.Tank
{
    public class TankService : MonosingletonGeneric<TankService>
    {

        //This is Singleton class.
        public TankView tank3DModel1;

       
       

        protected override void Awake()
        {
            
            base.Awake();
            Debug.Log("This message is from Tank Service");
            
        }


        private void Start()
        {
                CreateNewTank();  
        }

      
        //Method for creating new TC.Try calling this in TankView. This is returning
        //TankController.
        public  TankController CreateNewTank()
        {
            //Created a first tank model, and prefab is the 3d model(prefab)
            //with which this TankView script is attached to.
            TankModel tankModel1 = tank1();


            //Created a new tankcontroller which is using reference of tankModel(Script) 
            //and Prefab with TankView attached.
            TankController tankcontroller1 = new TankController(tankModel1, tank3DModel1);


            return tankcontroller1;
        }

        //Create a tank1 model which is a static method.
        public static TankModel tank1()
        {
           return new TankModel(40, 100);
        }

      
        
        
      
    }
}

