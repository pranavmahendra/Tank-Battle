using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank.Tank
{
    public class TankModel
    {
        //Constructor
        public TankModel(int speed, int health)
        {
            Speed = speed;
            Health = health;
        }

        public int Speed;
        public int Health;

        public Rigidbody rb3d;
    }

    

    
}


