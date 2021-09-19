using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("�ǰ� ����Ʈ")]
    [SerializeField] GameObject go_RicochetEffect;

    [Header("�Ѿ� ������")]
    [SerializeField] int damage;

    [Header("�ǰ� ȿ����")]
    [SerializeField] string sound_Ricochet;

    void OnCollisionEnter(Collision other)
    {
        ContactPoint contactPoint = other.contacts[0]; // ���� ����� ���˸�
        //SoundManager.instance.PlaySE("NormalGun_Ricochet");
        SoundManager.instance.PlaySE(sound_Ricochet);

        var clone = Instantiate(go_RicochetEffect, contactPoint.point, Quaternion.LookRotation(contactPoint.normal)); // ���˸� ����

        if (other.transform.CompareTag("Mine"))
        {
            other.transform.GetComponent<EnemyMine>().Damaged(damage);
        }

        Destroy(clone, 0.5f);
        Destroy(gameObject);
    }
}
