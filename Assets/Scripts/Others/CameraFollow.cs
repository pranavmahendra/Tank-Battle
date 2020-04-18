using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BattleTank.Tank;

public class CameraFollow : MonosingletonGeneric<CameraFollow>
{
    //Transfrom values for camera according to tankview transform values.


    public TankView tankView;

    //[SerializeField]
    //private float xMax;
    //[SerializeField]
    //private float xMin;
    //[SerializeField]
    //private float yMax;
    //[SerializeField]
    //private float yMin;



    void Start()
    {

        tankView = TankService.Instance.returnTankView();

        //transform.position = new Vector3(20f, 0f, -18f);

        Debug.Log(tankView.transform.position);

        Debug.Log(transform.position);

    }


    void Update()
    {
        transform.position = new Vector3(tankView.transform.position.x, tankView.transform.position.y, -18f) * Time.deltaTime;
        
    }
}


