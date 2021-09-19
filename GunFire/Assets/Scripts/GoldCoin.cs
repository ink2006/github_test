using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldCoin : MonoBehaviour
{
    [Header("회전 속도")]
    [SerializeField] private float spinSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, spinSpeed, 0) * Time.deltaTime, Space.World);
    }
}
