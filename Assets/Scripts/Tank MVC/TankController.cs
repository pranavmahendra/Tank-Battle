﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BattleTank.bullet;


namespace BattleTank.Tank
{
    public class TankController
    {
        
        public TankController(TankModel tankModel, TankView tankPrefab)
        {
            this.TankModel = tankModel;

            this.TankView = GameObject.Instantiate<TankView>(tankPrefab);

            TankView.initialize(this);

        }

        public TankModel TankModel { get; }
        public TankView TankView { get; }

        public float appliedForce = 5f;
        public float rayDistance = 100f;
        

    
        public TankModel getModel()
        {
            return TankModel;
        }


        //Tank Fire Logic.
        public void tankFire()
        {
            Debug.Log("Tank Fired a bullet ");
            Debug.DrawRay(TankView.barrelTip.position, TankView.barrelTip.forward * rayDistance, Color.green);
            
            TankService.Instance.bulletService.CreateNewBullet(1).setPosition(TankView.barrelTip.position, Quaternion.LookRotation(TankView.barrelTip.forward));

            //TankService.Instance._bulletService.CreateNewBullet(new Vector3(6f,0f,-13f), Quaternion.identity, 1);

            RaycastHit hit;
            if(Physics.Raycast(TankView.barrelTip.position, TankView.barrelTip.forward, out hit, rayDistance, TankView.rayMask))
            {
                if (hit.rigidbody != null)
                {
                    Debug.Log("Missile has hit enemy tank");
                }
            }
           
            
        }

        //Movement of tank.
        public void movement()
        {
            float xAxis = Input.GetAxisRaw("Horizontal1");
            float vAxis = Input.GetAxisRaw("Vertical1");

            TankView.transform.Translate(new Vector3(xAxis, TankView.transform.position.y, vAxis) * TankModel.Speed * Time.deltaTime);
        }


        //Mouse rotation.
        public void mouseRotation()
        {
            //Get the Screen positions of the object
            Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(TankView.transform.position);

            //Get the Screen position of the mouse
            Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);

            //Get the angle between the points
            float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);

            
            TankView.transform.rotation = Quaternion.Euler(new Vector3(0f, -angle, 0f));
        }

        float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
        {
            return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
        }

   

    }

}
