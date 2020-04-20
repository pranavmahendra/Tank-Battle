using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BattleTank.Tank;

public class CameraFollow : MonosingletonGeneric<CameraFollow>
{
    //Transfrom values for camera according to tankview transform values.



    public TankView tankView;


    void Start()
    {
        

    }


    void Update()
    {
    
        transform.position = new Vector3(tankView.transform.position.x, tankView.transform.position.y, transform.position.z);
        
    }

    public void followPlayerCamera()
    {
        tankView = TankService.Instance.tankLists[0].TankView;
    }
}


