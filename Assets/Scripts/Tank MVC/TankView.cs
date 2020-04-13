using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BattleTank.Tank
{
    public class TankView : MonoBehaviour 
    {

        private TankController tankController;

        private void Start()
        {

            Debug.Log("This tank view is of " + tankController.TankModel.TankType);

        }

        private void Update()
        {
            fireOnPress();

            tankController.movement();

            tankController.mouseRotation();

            
        }

        //Initialization Method.
        public void initialize(TankController tankController)
        {
            this.tankController = tankController;
        }


        //Fire on press.
        public void fireOnPress()
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                tankController.tankFire();
            }
        }

 
    

    }
}
