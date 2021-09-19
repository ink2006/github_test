using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static bool canMove = true;

    [Header("�ӵ� ����")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jetPackSpeed;

    private AudioSource audioSource;

    Rigidbody myRigid;

    public bool IsJet {get; private set; }

    [Header("��ƼŬ �ý���(�ν���)")]
    [SerializeField] ParticleSystem ps_RightEngine;
    [SerializeField] ParticleSystem ps_LeftEngine;

    JetEngineFuelManager theFuel;

    void Start()
    {
        IsJet = false;
        myRigid = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        theFuel = FindObjectOfType<JetEngineFuelManager>();
    }

    void Update()
    {
        TryMove();
        TryJet();
    }

    void TryMove()
    {
        if (Input.GetAxisRaw("Horizontal") != 0 && canMove)
        {
            Vector3 moveDir = new Vector3(0, 0, Input.GetAxisRaw("Horizontal"));
            myRigid.AddForce(moveDir * moveSpeed);
        }
    }

    void TryJet()
    {
        if (Input.GetKey(KeyCode.Space) && theFuel.IsFuel && canMove  == true)
        {
            if (!IsJet)
            {
                ps_RightEngine.Play();
                ps_LeftEngine.Play();
                audioSource.Play();
                IsJet = true;
            }
            myRigid.AddForce(Vector3.up * jetPackSpeed);

        }
        else
        {
            if (IsJet)
            {
                ps_RightEngine.Stop();
                ps_LeftEngine.Stop();
                audioSource.Stop();
                IsJet = false;
            }
            myRigid.AddForce(Vector3.down * jetPackSpeed);
        }

        
    }
}
