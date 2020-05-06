using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXService : MonosingletonGeneric<VFXService>
{
    public List<ParticleSystem> particles;

    public void CreateBulletExplosion(Vector3 bulletPosition,Quaternion bulletRotation)
    {
        Instantiate(particles[1], bulletPosition, bulletRotation);
        particles[1].Play();
    }

    public void CreateTankExplosion(Vector3 tankPos, Quaternion tankRotation)
    {
        Instantiate(particles[0], tankPos, tankRotation);
        particles[0].Play();
    }

   //public void CreateDust(Vector3 playerPos, Quaternion playerRot)
   // {
   //     Instantiate(particles[2], playerPos, playerRot);
   //     particles[2].Play();
   // }

}
