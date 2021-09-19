using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingText : MonoBehaviour
{

    [SerializeField] float destroyTime;
    [SerializeField] Animation anim;


    void Start()
    {
        anim.Play();
        Destroy(gameObject, destroyTime);
    }

    
}
