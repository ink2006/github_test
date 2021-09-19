using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StatusManager : MonoBehaviour
{
    [SerializeField] int maxHp;
    int currentHp;

    [SerializeField] Text[] txt_HpArray;

    bool isInvinceibleMode = false; // blink동안 무적

    [SerializeField] float blinkSpeed;
    [SerializeField] int blinkCount;

    [SerializeField] MeshRenderer mesh_PlayerGraphics;

    private void Start()
    {
        currentHp = maxHp;
        UpdateHpStatus();
    }

    public void IncreaseHp(int _num)
    {
        if (currentHp == maxHp)
            return;

        currentHp += _num;
        if (currentHp > maxHp)
            currentHp = maxHp;

        UpdateHpStatus();
    }

    public void DecreaseHp(int _num)
    {
        if (!isInvinceibleMode){
            currentHp -= _num;
            UpdateHpStatus();

            if (currentHp <= 0)
                PlayerDead();

            SoundManager.instance.PlaySE("Player_Damaged");
            StartCoroutine(BlinkCoroutine());
        }
    }


    IEnumerator BlinkCoroutine()
    {
        isInvinceibleMode = true;
        for (int i = 0; i < blinkCount * 2; i++) // blink 짝수 유지
        {
            mesh_PlayerGraphics.enabled = !mesh_PlayerGraphics.enabled;
            yield return new WaitForSeconds(blinkSpeed);
        }
        isInvinceibleMode = false;
    }

    void UpdateHpStatus()
    {
        for (int i = 0; i < txt_HpArray.Length; i++)
        {
            if (i < currentHp)
                txt_HpArray[i].gameObject.SetActive(true);
            else
                txt_HpArray[i].gameObject.SetActive(false);
        }
    }

    void PlayerDead()
    {
        Debug.Log("플레이어 사망");

        SceneManager.LoadScene("Title");
    }
}
