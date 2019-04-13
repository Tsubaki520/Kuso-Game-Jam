using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioListHolder[ ] AudioList;
    private AudioSource audioSource;
    private bool canPlayAudio;

    public void Init ()
    {
        audioSource = gameObject.GetComponent<AudioSource> ();
        canPlayAudio = false;
        GameManager.AudioReady = true;
    }

    void Start ()
    {
        Init ();
    }

    void Update ()
    {
        if (!GameManager.SceneReady) return;

        if (!canPlayAudio)
        {
            if (GameManager.SceneReady)
            {
                audioSource.enabled = true;
                canPlayAudio = true;
            }
            else
            {
                audioSource.enabled = false;
            }
        }
    }

    [System.Serializable]
    public class AudioListHolder
    {
        public int AudioNum;
        public AudioClip audio;
    }

    /// <summary>
    /// 單次播放AudioList內的音效 (歌曲編號 1~?, 音量大小 0~1)
    /// </summary>
    /// <param name="AudioNum">歌曲編號 1~?</param>
    /// <param name="AudioVolume">音量大小 0~1</param>
    public void PlayAudio (int AudioNum, float AudioVolume)
    {
        AudioNum = AudioList[AudioNum].AudioNum;
        audioSource.PlayOneShot (AudioList[AudioNum].audio);
        audioSource.volume = AudioVolume;
    }
}
