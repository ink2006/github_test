using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    [SerializeField] Gun[] guns;
    const int NORMAL_GUN = 0; // ������ �����    ����Ұ�

    GunController theGC;

    void Start()
    {
        theGC = FindObjectOfType<GunController>();
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.transform.CompareTag("Item"))
        {
            Item item = other.GetComponent<Item>(); // item ������ �浹 ������Ʈ ��������

            int extra = 0;

            if(item.itemType == ItemType.Score)
            {
                SoundManager.instance.PlaySE("GoldCoin");
                extra = item.extraScore;
                ScoreManger.extraScore += extra;
            }
            else if (item.itemType == ItemType.NormalGun_Bullet)
            {
                SoundManager.instance.PlaySE("Item_NormalGun");
                extra = item.extraBullet;
                guns[NORMAL_GUN].bulletCount += extra;
                theGC.BulletUiSetting();
            }
            string message = "+ " + extra; // string���� ����
            FloatingTextManager.instance.CreateFloatingText(other.transform.position, message);

            Destroy(other.gameObject);


        }
    }
}
