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

    void Start ()
    {
        TimeNumber = GameManager.TimeNumber;
        GameManager.UIReady = true;
    }

    void Update ()
    {
        ShowNumber ();
    }

    void ShowNumber ()
    {
        Nums[0].GetComponent<Image> ().sprite = NumSprites[TimeNumber % 10];
        Nums[1].GetComponent<Image> ().sprite = NumSprites[TimeNumber / 10 % 10];
    }

    public void PushButton0 ()
    {

    }

    public void PushButton1 ()
    {

    }
}
