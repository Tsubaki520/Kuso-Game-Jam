using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;

    public AudioManager audioManager;
    public MainController mainController;
    public SceneController sceneController;
    public CameraController cameraController;
    public UIController uI;

    public const int TimeNumber = 60;

    public static bool AreaReady, AudioReady, CameraReady, UIReady, playerReady;
    /// <summary>
    /// 所有關卡系統準備完成
    /// </summary>
    public static bool SceneReady
    {
        get { return AreaReady && AudioReady && CameraReady && UIReady && playerReady; }
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
        audioManager = GetComponentInChildren<AudioManager> ();
        mainController = GetComponentInChildren<MainController> ();
        sceneController = GetComponentInChildren<SceneController> ();
        cameraController = GetComponentInChildren<CameraController> ();
        uI = GetComponentInChildren<UIController> ();
    }

    void Start ()
    {

    }

    void Update ()
    {
        if (!SceneReady) return;

        if (UpdateCountdownTImer (TimeNumber))
        {

        }
    }

    private void OnDestroy ()
    {
        Instance = null;
    }

    /// <summary>
    /// 倒數計時器每偵減少時間變數，倒數至0時回傳true
    /// </summary>
    /// <param name="timer">倒數用時間變數</param>
    public static bool UpdateCountdownTImer (float timer)
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
}
