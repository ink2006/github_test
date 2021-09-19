using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    [SerializeField] Text txt_CurrentStage;
    [SerializeField] GameObject go_UI;
    [SerializeField] ScoreManger theSM; // ScoreManager ��������

    [SerializeField] GameObject[] go_Stages;
    int currentStage = 0;

    [SerializeField] Rigidbody playerRigid;
    [SerializeField] Transform tf_OriginPos;

    public void ShowClearUI()
    {
        PlayerController.canMove = false; // Ŭ����� player ����
        playerRigid.isKinematic = true; // ����ȿ�� off
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

            playerRigid.gameObject.transform.position = tf_OriginPos.position; // player ������ġ��
            go_Stages[currentStage++].SetActive(false); // 0��(�迭) stage ��Ȱ��ȭ
            go_Stages[currentStage].SetActive(true); // ����(�迭) stage Ȱ��ȭ
            go_UI.SetActive(false);
        }
        else
        {
            Debug.Log("��� �������� Ŭ����");
        }
        
    }
    public void ExitBtn()
    {
        SceneManager.LoadScene("Title");
    }

}
