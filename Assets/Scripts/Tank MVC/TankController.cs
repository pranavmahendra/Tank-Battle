using System.Collections;
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

    
        public TankModel getModel()
        {
            return TankModel;
        }

        public void tankFire()
        {
            Debug.Log("Tank Fired a bullet ");
           
            TankService.Instance._bulletService.CreateNewBullet(1);
            
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

            //Ta Daaa
            TankView.transform.rotation = Quaternion.Euler(new Vector3(0f, -angle, 0f));
        }

        float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
        {
            return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
        }

    }

}
