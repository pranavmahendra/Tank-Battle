using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank.Tank
{
    public class TankModel
    {
        //Constructor
        public TankModel(int speed, int health, Color color)
        {
            Speed = speed;
            Health = health;
            Color = color;
            
        }

        public int Speed;
        public int Health;
        public Color Color;
       

        public Rigidbody rb3d;

      
    }

    

    
}


