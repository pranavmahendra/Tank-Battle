using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BattleTank.Tank
{
    public class TankView : MonoBehaviour
    {

        private TankController tankController;

        public TankType tankType;

        private Renderer tankRenderer;


        private Rigidbody rb3d;
        
       


        private void Start()
        {
            tankType = tankController.GetModel().TankType;

            rb3d = GetComponent<Rigidbody>();
            


            Debug.Log("This is from TankView script.");


            //Debug.Log("Position of Tank1 is " + currentValues);

        }



        private void Update()
        {


            //Call TankFire method from the tank controller script.
            if (Input.GetKeyDown(KeyCode.F))
            {
                tankController.tankFire();
                //Debug.Log("Tank is now firing");

            }

            tankMovement();

            rotationMovement();
        }




        //Set Color
        //public void setColor()
        //{
        //    tankRenderer = GetComponentInChildren<MeshRenderer>();
        //    tankRenderer.material.SetColor("_Color", tankController.GetModel().Color);
        //}


        //Linking view and controller.
        public void Initialize(TankController controller)
        {
            this.tankController = controller;
        }



        //Tank Movement
        public void tankMovement()
        {
            float hAxis = Input.GetAxis("Horizontal1");
            float vAxis = Input.GetAxis("Vertical1");

            Vector3 movement = new Vector3(hAxis, 0, vAxis) * tankController.GetModel().Speed * Time.deltaTime;

            rb3d.MovePosition(transform.position + movement);
        }

        //Tank Rotation
        public void rotationMovement()
        {

            float rAxis = Input.GetAxis("Mouse Y");


            Vector3 rotation = new Vector3(transform.rotation.x, rAxis, transform.rotation.z) * Time.deltaTime;
            transform.RotateAround(rotation, rAxis);

        }

    }
}
