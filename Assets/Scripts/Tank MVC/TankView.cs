using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BattleTank.Tank
{
    public class TankView : MonoBehaviour
    {

        private TankController tankControllerRef;
        private TankModel tankModelRef;
        private Renderer tankRenderer;

      
        //tank related data.
        private float speed;
        private Color colortank;
        
       

        private void Awake()
        {
            Initialize(tankControllerRef);

            //Reference to tankmodel1 inside tank service which is static.
            tankModelRef = TankService.tank1();


            tankModelCreation(tankModelRef);

            
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

            rotationMovement();
        }


        //Called in awake.
        private void tankModelCreation(TankModel model)
        {
            //Initialize the value of speed from tankmodelRef.
            //tankmodelref which is getting values from tank service tank1 method.
            speed = model.Speed;
            colortank = model.Color;

            setColor();
        }

        //Set Color
       public void setColor()
        {
            tankRenderer = GetComponentInChildren<MeshRenderer>();
            tankRenderer.material.SetColor("_Color", colortank);
        }
       
        public void Initialize(TankController TCcontroller)
        {
            tankControllerRef = TCcontroller;
        }


        //Tank Movement
        public void tankMovement()
        {
            float hAxis = Input.GetAxis("Horizontal1");
            float vAxis = Input.GetAxis("Vertical1");

            Vector3 movement = new Vector3(hAxis, 0, vAxis) * speed * Time.deltaTime;

            tankModelRef.rb3d.MovePosition(transform.position + movement);
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
