using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum Status { MENU, PLAY, OVER, CLEAR }
    public Status GameStatus;
    public static GameManager Instance = null;

    public AudioManager audioManager;
    public MainController mainController;
    public SceneController sceneController;
    public UIController uI;

    public int TimeNumber;
    private bool isCodeDown = false;

    public static bool AreaReady, AudioReady, UIReady, playerReady;
    /// <summary>
    /// 所有關卡系統準備完成
    /// </summary>
    public static bool SceneReady
    {
        get { return AreaReady && AudioReady && UIReady && playerReady; }
    }

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

        Init ();
    }

    private void Init ()
    {
        GameStatus = Status.MENU;
        audioManager = GetComponentInChildren<AudioManager> ();
        mainController = GameObject.FindGameObjectWithTag ("GameController").GetComponent<MainController> ();
        sceneController = GetComponentInChildren<SceneController> ();
        uI = GetComponentInChildren<UIController> ();
        TimeNumber = 60;
    }

    void Update ()
    {
        if (!SceneReady) return;

        if (GameStatus == Status.PLAY && TimeNumber > 0 && !isCodeDown)
        {
            isCodeDown = true;
            StartCoroutine (TimeCounter ());
            TimeNumber--;
            if (TimeNumber <= 0)
            {
                GameStatus = Status.OVER;
            }
        }

        if (GameStatus == Status.CLEAR)
        {
            Init ();
            audioManager.Init ();
            mainController.Init ();
            sceneController.Init ();
            uI.Init ();
        }
    }

    IEnumerator TimeCounter ()
    {
        yield return new WaitForSeconds (1);
        isCodeDown = false;
    }

    private void OnDestroy ()
    {
        Instance = null;
    }
}
