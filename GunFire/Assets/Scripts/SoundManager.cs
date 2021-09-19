using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string soundName;
    public AudioClip clip;
}

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [Header("���� ���")]
    [SerializeField] Sound[] bgmSounds;
    [SerializeField] Sound[] sfxSounds;

    [Header("BGM Player")]
    [SerializeField] AudioSource bgmPlayer;

    [Header("ȿ���� �÷��̾�")]
    [SerializeField] AudioSource[] sfxPlayer;


    void Start()
    {
        instance = this;
        PlayRandomBGM();
    }

    public void PlaySE(string _soundName)
    {
        for (int i = 0; i < sfxSounds.Length; i++)
        {
            if(_soundName == sfxSounds[i].soundName)
            {
                for (int x = 0; x < sfxPlayer.Length; x++)
                {
                    if (!sfxPlayer[x].isPlaying)
                    {
                        sfxPlayer[x].clip = sfxSounds[i].clip;
                        sfxPlayer[x].Play();

                        return;
                    }
                }
                Debug.Log("��� ȿ���� player�� ������Դϴ�.");
                return;
            }
        }
        Debug.Log("��ϵ� ȿ������ �����ϴ�.");
    }

    public void PlayRandomBGM()
    {
        int random = Random.Range(0, bgmSounds.Length);
        bgmPlayer.clip = bgmSounds[random].clip;
        bgmPlayer.Play();
    }

}
