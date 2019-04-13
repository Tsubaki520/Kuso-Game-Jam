using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private MainController Player;

    void Start ()
    {
        Player = GameManager.Instance.mainController;
        GameManager.CameraReady = true;
    }

    void Update ()
    {

    }
}
