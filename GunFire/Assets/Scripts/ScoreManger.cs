using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManger : MonoBehaviour
{
    int currentScore;
    public int GetCurrentScore() { return currentScore; } // StageManager 참조를위해 반환
    public void ResetCurrentScore() { currentScore = 0; distanceScore = 0; maxDistance = 0; extraScore = 0; }
    public static int extraScore;
    int distanceScore;
    float maxDistance; //플레이어 최대 이동거리 (점수 중복 획득 방지)
    float originPosZ; // 시작시 점수획득 방지

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
            distanceScore = Mathf.RoundToInt(maxDistance - originPosZ); // 정수형태로 변환+반올림
        }

        currentScore = extraScore +  distanceScore;
        txt_Score.text = "Score : " + string.Format("{0:000,000}", currentScore);
    }
}
