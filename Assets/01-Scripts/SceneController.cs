using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public static SceneController Instance = null;

    [Header ("場景物件")]
    public GameObject[ ] SceneObjects;
    [Header ("生成物件")]
    public GameObject[ ] Items;
    [Space (15)]
    [SerializeField]
    private GameObject insObj;
    [SerializeField]
    private List<GameObject> insItems = new List<GameObject> ();

    private bool isSetObject;
    public bool isSetItem;

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

    void Start ()
    {
        Init ();
    }

    public void Init ()
    {
        if (insObj != null) Destroy (insObj);
        insObj = null;
        insItems.Clear ();
        isSetObject = true;
        isSetItem = false;
        GameManager.AreaReady = true;
    }

    void Update ()
    {
        if (!GameManager.SceneReady) return;

        if (GameManager.Instance.GameStatus == GameManager.Status.PLAY)
        {
            SetObject (isSetObject);
            CreateItem (isSetItem);
        }
    }

    private void SetObject (bool setObject)
    {
        if (setObject)
        {
            if (GameManager.Instance.uI.Button1 && !GameManager.Instance.uI.Button2)
            {
                CreateObject (0);
            }
            if (GameManager.Instance.uI.Button2 && !GameManager.Instance.uI.Button1)
            {
                CreateObject (1);
            }
        }
        else
        {
            if (!GameManager.Instance.uI.Button1 && !GameManager.Instance.uI.Button2)
            {
                Destroy (insObj);
                isSetObject = true;
            }
        }
    }

    private void CreateObject (int i)
    {
        MainController controller = GameManager.Instance.mainController;
        insObj = Instantiate (SceneObjects[i], controller.transform);
        controller.targetObj = insObj;
        isSetObject = false;
    }

    private void CreateItem (bool setItem)
    {
        if (GameManager.Instance.uI.Button1 && setItem)
        {
            insItems.Add (Instantiate (Items[Random.Range (0, Items.Length)], transform.GetChild (0)));
            insItems[insItems.Count - 1].transform.position = new Vector3 (Random.Range (-0.45f, 0.45f), -0.1745f, Random.Range (0.4f, 0.9f));
            insItems.Add (Instantiate (Items[0], transform.GetChild (0)));
            insItems[insItems.Count - 1].transform.position = new Vector3 (Random.Range (-0.45f, 0.45f), -0.1745f, Random.Range (0.4f, 0.9f));
        }
        if (GameManager.Instance.GameStatus == GameManager.Status.OVER)
        {
            insItems.Clear ();
        }
    }
}
