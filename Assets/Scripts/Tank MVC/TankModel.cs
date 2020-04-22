using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank.Tank
{
    public class TankModel
    {
        
        public TankModel(TankScriptableObjects tankScriptableObjects)
        {
            this.TankType = tankScriptableObjects.TankType;
            this.Speed = (int)tankScriptableObjects.Speed;
            this.Health = (int)tankScriptableObjects.Health;
            this.BulletType = tankScriptableObjects.bullet;
        }

        public TankType TankType { get; }
        public int Speed { get; }
        public int Health { get; }
        public BulletType BulletType { get; }
    }

    

    
}


