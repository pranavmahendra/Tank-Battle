using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank.bullet
{
    public class BulletView : MonoBehaviour
    {
        public BulletController bulletController;

        private void Start()
        {

        }

        private void Update()
        {

        }

        public void initialize(BulletController bulletController)
        {
            this.bulletController = bulletController;
        }

    }
}