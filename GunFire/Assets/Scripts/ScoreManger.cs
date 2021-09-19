using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManger : MonoBehaviour
{
    int currentScore;
    public int GetCurrentScore() { return currentScore; } // StageManager ���������� ��ȯ
    public void ResetCurrentScore() { currentScore = 0; distanceScore = 0; maxDistance = 0; extraScore = 0; }
    public static int extraScore;
    int distanceScore;
    float maxDistance; //�÷��̾� �ִ� �̵��Ÿ� (���� �ߺ� ȹ�� ����)
    float originPosZ; // ���۽� ����ȹ�� ����

    [SerializeField] Text txt_Score;
    [SerializeField] Transform tf_Player;

    void Start()
    {
        originPosZ = tf_Player.position.z;
    }

    void Update()
    {
        if(tf_Player.position.z > maxDistance)
        {
            maxDistance = tf_Player.position.z;
            distanceScore = Mathf.RoundToInt(maxDistance - originPosZ); // �������·� ��ȯ+�ݿø�
        }

        currentScore = extraScore +  distanceScore;
        txt_Score.text = "Score : " + string.Format("{0:000,000}", currentScore);
    }
}
