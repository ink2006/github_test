using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Score,
    NormalGun_Bullet, 
}

public class Item : MonoBehaviour
{
    [Header("È¸Àü ¼Óµµ")]
    [SerializeField] private float spinSpeed;

    public ItemType itemType;
    public int extraScore;
    public int extraBullet; // ÃÑ¾Ë È¹µæ

    void Update()
    {
        transform.Rotate(new Vector3(0, spinSpeed, 0) * Time.deltaTime, Space.World);
    }
}    
