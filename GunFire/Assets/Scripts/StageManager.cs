using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    [SerializeField] Text txt_CurrentStage;
    [SerializeField] GameObject go_UI;
    [SerializeField] ScoreManger theSM; // ScoreManager 참조변수

    [SerializeField] GameObject[] go_Stages;
    int currentStage = 0;

    [SerializeField] Rigidbody playerRigid;
    [SerializeField] Transform tf_OriginPos;

    public void ShowClearUI()
    {
        PlayerController.canMove = false; // 클리어시 player 멈춤
        playerRigid.isKinematic = true; // 물리효과 off
        go_UI.SetActive(true);
        txt_CurrentStage.text = string.Format("{0:000,000}", theSM.GetCurrentScore());
    }

    public void NextBtn()
    {
        if(currentStage < go_Stages.Length - 1)
        {
            PlayerController.canMove = true;
            playerRigid.isKinematic = false;
            theSM.ResetCurrentScore();

            playerRigid.gameObject.transform.position = tf_OriginPos.position; // player 시작위치로
            go_Stages[currentStage++].SetActive(false); // 0번(배열) stage 비활성화
            go_Stages[currentStage].SetActive(true); // 다음(배열) stage 활성화
            go_UI.SetActive(false);
        }
        else
        {
            Debug.Log("모든 스테이지 클리어");
        }
        
    }
    public void ExitBtn()
    {
        SceneManager.LoadScene("Title");
    }

}
