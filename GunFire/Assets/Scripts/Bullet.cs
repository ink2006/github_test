using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("피격 이펙트")]
    [SerializeField] GameObject go_RicochetEffect;

    [Header("총알 데미지")]
    [SerializeField] int damage;

    [Header("피격 효과음")]
    [SerializeField] string sound_Ricochet;

    void OnCollisionEnter(Collision other)
    {
        ContactPoint contactPoint = other.contacts[0]; // 가장 가까운 접촉면
        //SoundManager.instance.PlaySE("NormalGun_Ricochet");
        SoundManager.instance.PlaySE(sound_Ricochet);

        var clone = Instantiate(go_RicochetEffect, contactPoint.point, Quaternion.LookRotation(contactPoint.normal)); // 접촉면 방향

        if (other.transform.CompareTag("Mine"))
        {
            other.transform.GetComponent<EnemyMine>().Damaged(damage);
        }

        Destroy(clone, 0.5f);
        Destroy(gameObject);
    }
}
