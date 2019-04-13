using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public static SceneController Instance = null;

    public GameObject[ ] Objects;

    private void Awake ()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy (gameObject);
            return;
        }
    }

    private void Init ()
    {
        Objects[0].SetActive (false);
        Objects[3].SetActive (false);
    }

    void Start ()
    {
        Init ();
        GameManager.AreaReady = true;
    }

    void Update ()
    {
        if (!GameManager.SceneReady) return;


    }
}
