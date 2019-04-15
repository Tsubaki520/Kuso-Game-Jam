using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private int TimeNumber;
    [SerializeField]
    private GameObject[ ] Nums;
    [SerializeField]
    private Sprite[ ] NumSprites;
    [SerializeField]
    private Button[ ] Buttons;
    [SerializeField]
    private GameObject Menu;
    [SerializeField]
    private GameObject End;

    public bool SetButton, Button1, Button2;

    void Start ()
    {
        Init ();
    }

    public void Init ()
    {
        for (int i = 1 ; i < Buttons.Length ; i++)
        {
            Buttons[i].gameObject.SetActive (false);
        }
        SetButton = Button1 = Button2 = false;
        Menu.SetActive (true);
        End.SetActive (false);
        GameManager.UIReady = true;
    }

    void Update ()
    {
        if (!GameManager.SceneReady) return;

        ButtonListener ();
        ShowNumber ();
        ShowButton (SetButton);

        if (GameManager.Instance.GameStatus == GameManager.Status.PLAY)
        {
            TimeNumber = GameManager.Instance.TimeNumber;
        }
    }

    private void ButtonListener ()
    {
        Buttons[0].onClick.AddListener (StartGame);
        Buttons[1].onClick.AddListener (PushButton1);
        Buttons[2].onClick.AddListener (PushButton2);
        Buttons[3].onClick.AddListener (ResumeGame);
        Buttons[4].onClick.AddListener (QuitGame);
    }

    private void ShowButton (bool setUP)
    {
        if (setUP == false)
        {
            if (GameManager.Instance.GameStatus == GameManager.Status.MENU)
            {
                Menu.SetActive (true);
                Buttons[0].gameObject.SetActive (true);
                Buttons[1].gameObject.SetActive (false);
                Buttons[2].gameObject.SetActive (false);
                Buttons[4].gameObject.SetActive (true);
            }

            if (GameManager.Instance.GameStatus == GameManager.Status.PLAY)
            {
                SetButton = true;
                Menu.SetActive (false);
                Buttons[1].gameObject.SetActive (true);
                Buttons[2].gameObject.SetActive (true);
            }
        }
        else
        {
            if (GameManager.Instance.GameStatus == GameManager.Status.OVER)
            {
                Buttons[3].gameObject.SetActive (true);
                Buttons[4].gameObject.SetActive (true);
                End.SetActive (true);
            }
        }
    }

    private void ShowNumber ()
    {
        Nums[0].GetComponent<Image> ().sprite = NumSprites[TimeNumber / 10 % 10];
        Nums[1].GetComponent<Image> ().sprite = NumSprites[TimeNumber % 10];
    }

    public void PushButton1 ()
    {
        if (!Button2)
        {
            Button1 = !Button1;
        }
    }

    public void PushButton2 ()
    {
        if (!Button1)
        {
            Button2 = !Button2;
        }
    }

    public void StartGame ()
    {
        GameManager.Instance.GameStatus = GameManager.Status.PLAY;
        Menu.SetActive (false);
        Buttons[0].gameObject.SetActive (false);
        Buttons[4].gameObject.SetActive (false);
    }

    public void ResumeGame ()
    {
        GameManager.Instance.GameStatus = GameManager.Status.CLEAR;
        Buttons[3].gameObject.SetActive (false);
        End.SetActive (false);
        GameManager.Instance.audioManager.PlayAudio (2, 0.3f);
    }

    public void QuitGame ()
    {
        GameManager.Instance.audioManager.PlayAudio (1, 0.3f);
        Application.Quit ();
    }
}
