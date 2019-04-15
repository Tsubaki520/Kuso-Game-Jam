using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{
    private float moveSpeed = 10;

    public GameObject targetObj;

    void Start ()
    {
        Init ();
    }

    public void Init ()
    {
        targetObj = null;
        GameManager.playerReady = true;
    }

    void Update ()
    {
        if (!GameManager.SceneReady) return;

        if (GameManager.Instance.GameStatus == GameManager.Status.PLAY)
        {
            Move ();
            CheckMouseBotton ();
        }
    }

    private void Move ()
    {
        if (Input.GetAxis ("Mouse X") != 0)
        {
            transform.position += new Vector3 (Input.GetAxisRaw ("Mouse X") * Time.deltaTime * moveSpeed,
                0f, Input.GetAxisRaw ("Mouse Y") * Time.deltaTime * moveSpeed);
        }
    }

    private void CheckMouseBotton ()
    {
        if (Input.GetMouseButtonUp (0))
            OnMouseButtonDown (0);

        if (Input.GetMouseButtonDown (0))
            OnMouseButtonDown (1);

        if (Input.GetMouseButtonDown (1))
            OnMouseButtonDown (2);
    }

    private void OnMouseButtonDown (int type)
    {
        if (type == 0)
        {
            if (targetObj)
            {
                if (GameManager.Instance.uI.Button1)
                {
                    targetObj.transform.position += new Vector3 (0, -0.2f, 0);
                    targetObj.transform.Rotate (0, 0, -135);
                    GameManager.Instance.sceneController.isSetItem = false;
                }
                if (GameManager.Instance.uI.Button2)
                {
                    targetObj.transform.position += new Vector3 (0, -0.1f, 0);
                    targetObj.transform.Rotate (-30, 0, 0);
                }
            }
        }
        else if (type == 1)
        {
            if (targetObj)
            {
                if (GameManager.Instance.uI.Button1)
                {
                    targetObj.transform.position += new Vector3 (0, 0.2f, 0);
                    targetObj.transform.Rotate (0, 0, 135);
                    GameManager.Instance.sceneController.isSetItem = true;
                    GameManager.Instance.audioManager.PlayAudio (0, 1);
                }
                if (GameManager.Instance.uI.Button2)
                {
                    targetObj.transform.position += new Vector3 (0, 0.1f, 0);
                    targetObj.transform.Rotate (30, 0, 0);
                    GameManager.Instance.audioManager.PlayAudio (0, 1);
                }
            }
        }
        else if (type == 2)
        {
            GameManager.Instance.uI.Button1 = GameManager.Instance.uI.Button2 = false;
        }
    }
}
