using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank.Tank
{
    public class TankModel
    {
        
        //Constructor
        public TankModel(TankScriptableObjects tankScriptableObject)
        {
            TankType = tankScriptableObject.TankType;
            Speed = (int)tankScriptableObject.Speed;
            Health = (int)tankScriptableObject.Health;
            //Color = color;
        }

        public TankType TankType { get; }
        public int Speed { get; private set; }
        public int Health { get; private set; }
        //public Color Color { get; private set; }
    }

    

    
}


