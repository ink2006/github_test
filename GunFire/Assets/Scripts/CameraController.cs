using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("ī�޶� ���� ���")]
    [SerializeField] Transform tf_Player;

    [Header("ī�޶� �ӵ� ����")] [Range(0, 1f)]
    [SerializeField] float chaseSpeed;

    float camNormalXPos;

    [SerializeField] [Header("�ν��� ���� ī�޶� x�Ÿ�")]
    float camJetXPos;
    float camCurrentXPos;

    [SerializeField]
    [Header("�ν��� ���� ī�޶� �̵��ӵ�")] [Range(0, 1f)]
    float bust_CameraSpeed;

    PlayerController thePlayer;

    // Start is called before the first frame update
    void Start()
    {
        thePlayer = tf_Player.GetComponent<PlayerController>();
        camNormalXPos = transform.position.x;
        camCurrentXPos = camNormalXPos;
    }

    // Update is called once per frame
    void Update()
    {
        if (thePlayer.IsJet)
            camCurrentXPos = camJetXPos;
        else
            camCurrentXPos = camNormalXPos;

        Vector3 movePos = Vector3.Lerp(transform.position, tf_Player.position, chaseSpeed);
        float cameraPosX = Mathf.Lerp(transform.position.x, camCurrentXPos, bust_CameraSpeed); 

        transform.position = new Vector3(cameraPosX, movePos.y, movePos.z);
    }
}
