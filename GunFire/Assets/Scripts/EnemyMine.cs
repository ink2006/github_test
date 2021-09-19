using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMine : MonoBehaviour
{
    [Header("Mine Control")]
    [SerializeField] float verticalDistance;
    [SerializeField] float horizontalDistance;
    [SerializeField] [Range(0, 1)] float moveSpeed;

    [SerializeField] int mine_Hp;

    [SerializeField] int damage;
    [SerializeField] GameObject go_EffectPrefab;

    Vector3 endPos1;
    Vector3 endPos2;
    Vector3 currentDestination;

    void Start()
    {
        Vector3 originPos = transform.position;
        endPos1.Set(originPos.x, originPos.y + verticalDistance, originPos.z + horizontalDistance);
        endPos2.Set(originPos.x, originPos.y - verticalDistance, originPos.z - horizontalDistance);
        currentDestination = endPos1;
    }

    void Update()
    {
        if ((transform.position - endPos1).sqrMagnitude <= 0.1f)
            currentDestination = endPos2;
        else if ((transform.position - endPos2).sqrMagnitude <= 0.1f)
            currentDestination = endPos1;

        transform.position = Vector3.Lerp(transform.position, currentDestination, moveSpeed);
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.transform.name == "Player")
        {
            other.transform.GetComponent<StatusManager>().DecreaseHp(damage);

            Explosion();           
        }
    }

    public void Damaged(int _num)
    {
        mine_Hp -= _num;
        if(mine_Hp <= 0)
        {
            Explosion();
        }
    }

    void Explosion()
    {
        SoundManager.instance.PlaySE("MineExplosion");
        GameObject clone = Instantiate(go_EffectPrefab, transform.position, Quaternion.identity);
        Destroy(clone, 2f);
        Destroy(gameObject);
    }
}
