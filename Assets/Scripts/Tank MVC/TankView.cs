using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BattleTank.Tank
{
    public class TankView : MonoBehaviour
    {

        private TankController tankControllerRef;
        private TankModel tankModelRef;

      
        //tank Movement
        public float speed;
        
       

        private void Awake()
        {
            //Reference to tankmodel1 inside tank service.
            tankModelRef = TankService.tank1();
            //Initialize the value of speed from tankmodelRef.
            //tankmodelref which is getting values from tank service tank1 method.
            speed = tankModelRef.Speed;

            

            Initialize(tankControllerRef);
        }



        private void Start()
        {
           

            tankModelRef.rb3d = GetComponent<Rigidbody>();

            Debug.Log("This is from TankView script.");

            
            //Debug.Log("Position of Tank1 is " + currentValues);

        }

        private void Update()
        {


            //Call TankFire method from the tank controller script.
            if (Input.GetKeyDown(KeyCode.F))
            {
                tankControllerRef.tankFire();
                //Debug.Log("Tank is now firing");

            }

            tankMovement();

        }

       
        public void Initialize(TankController TCcontroller)
        {
            tankControllerRef = TCcontroller;
        }


        public void tankMovement()
        {
            float hAxis = Input.GetAxis("Horizontal1");
            float vAxis = Input.GetAxis("Vertical1");

            Vector3 movement = new Vector3(hAxis, 0, vAxis) * speed * Time.deltaTime;

            tankModelRef.rb3d.MovePosition(transform.position + movement);
        }

    }
}
