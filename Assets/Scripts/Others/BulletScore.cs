using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BattleTank.Tank;
using UnityEngine.UI;
using BattleTank.bullet;
using TMPro;

public class BulletScore : MonoBehaviour
{
    private TextMeshProUGUI bulletsFiredText;
 

    private int bullets = 0;

    void Start()
    {
        BulletService.Instance.onBulletFire += BulletScore_OnBulletFire;

         bulletsFiredText = GetComponent<TextMeshProUGUI>();
    }


    private void BulletScore_OnBulletFire(TankView tankView)
    {
        bullets += 1;
        bulletsFiredText.text = "Bullets Fired: " + bullets;

    }

    private void OnDestroy()
    {
        BulletService.Instance.onBulletFire -= BulletScore_OnBulletFire;
    }


}
