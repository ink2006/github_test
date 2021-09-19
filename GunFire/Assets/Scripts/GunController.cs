using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunController : MonoBehaviour
{

    [Header("ÇöÀç ÀåÂøµÈ ÃÑ")]
    [SerializeField] Gun currentGun;

    float currentFireRate;

    [SerializeField] Text txt_CurrentGunBullet;

    void Start()
    {
        currentFireRate = 0;
        BulletUiSetting();
    }

    public void BulletUiSetting()
    {
        txt_CurrentGunBullet.text = string.Format("{0:000}", currentGun.bulletCount) + " / " + "000";
    }

    void Update()
    {
        FireRateCalc();
        TryFire();
        LockOnMouse();
    }

    void FireRateCalc()
    {
        if(currentFireRate > 0)
        {
            currentFireRate -= Time.deltaTime;
        }
    }

    void TryFire()
    {

        if(Input.GetMouseButton(0) && currentGun.bulletCount > 0)
        {
            if(currentFireRate <= 0)
            { 
                currentFireRate = currentGun.fireRate;
                Fire();
            }
            
        }
    }

    void Fire()
    {
        Debug.Log("»ç°Ý");
        currentGun.bulletCount--;
        BulletUiSetting();
        currentGun.animator.SetTrigger("GunFire");

        SoundManager.instance.PlaySE(currentGun.sound_Fire);

        currentGun.ps_MuzzleFlash.Play();
        var clone = Instantiate(currentGun.go_Bullet_Prefab, currentGun.ps_MuzzleFlash.transform.position, Quaternion.identity);
        clone.GetComponent<Rigidbody>().AddForce(transform.forward * currentGun.speed);
    }

    void LockOnMouse()
    {
        Vector3 cameraPos = Camera.main.transform.position; // main camera ÁÂÇ¥°ª
        // camera È­¸é»óÀÇ ÁÂÇ¥(Mouse)¸¦ 3D ÁÂÇ¥·Î ¸¸µë
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(
                  new Vector3(Input.mousePosition.x, Input.mousePosition.y, cameraPos.x));
        Vector3 target = new Vector3(0f, mousePos.y, mousePos.z);
        transform.LookAt(target);
    }
}
