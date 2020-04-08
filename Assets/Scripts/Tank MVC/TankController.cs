﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BattleTank.Tank
{
    public class TankController 
    {
        public TankController(TankModel tankmodel, TankView tankprefab)
        {
            TankModel = tankmodel;

            //Created a gameobject with TankView script on it. This is what creates a tank.
            TankView = GameObject.Instantiate<TankView>(tankprefab);

            //Tank Controller getting initialized.
            TankView.Initialize(this);
            
            
            Debug.Log("Tank View created", TankView);

        }  

             
        public TankModel TankModel { get; }

        public TankView TankView { get; }


        public void tankFire()
        {
            Debug.Log("Tank fired a bullet!!!!!!");
        }

     }
}