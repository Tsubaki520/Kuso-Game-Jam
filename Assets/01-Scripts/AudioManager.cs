using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioListHolder[ ] AudioList;
    private AudioSource audioSource;

    public void Init ()
    {
        GameManager.AudioReady = true;
    }

    void Start ()
    {
        audioSource = gameObject.GetComponent<AudioSource> ();
        Init ();
    }

    void Update ()
    {
        if (!GameManager.SceneReady) return;
    }

    [System.Serializable]
    public class AudioListHolder
    {
        public AudioClip audio;
    }

    /// <summary>
    /// 單次播放AudioList內的音效 (歌曲編號 0~?, 音量大小 0~1)
    /// </summary>
    /// <param name="AudioNum">歌曲編號 0~?</param>
    /// <param name="AudioVolume">音量大小 0~1</param>
    public void PlayAudio (int AudioNum, float AudioVolume)
    {
        audioSource.PlayOneShot (AudioList[AudioNum].audio);
        audioSource.volume = AudioVolume;
    }
}
