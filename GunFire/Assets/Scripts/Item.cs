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
    [Header("ȸ�� �ӵ�")]
    [SerializeField] private float spinSpeed;

    public ItemType itemType;
    public int extraScore;
    public int extraBullet; // �Ѿ� ȹ��

    void Update()
    {
        transform.Rotate(new Vector3(0, spinSpeed, 0) * Time.deltaTime, Space.World);
    }
}    
