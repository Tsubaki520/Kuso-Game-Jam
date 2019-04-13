using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{
    [Header ("Settings")]
    [Range (1, 20f)]
    public int moveSpeed = 2;
    [Range (1, 20f)]
    public int rotateSpeed = 10;
    [Range (0, 1f)]
    public float pointerRadius = 0.5f;

    private Transform mainCameraTransform;
    private Transform cameraDir;
    private Vector3 V3_moveVector = Vector3.zero;
    private Vector3 V3_lastPosition = Vector3.zero;

    public Transform pointer;
    public RectTransform pointerRange;

    private Camera cam;

    private void Awake ()
    {
        cam = Camera.main;
    }

    void Start ()
    {
        Init ();
    }

    private void Init ()
    {
        mainCameraTransform = Camera.main.transform;
        cameraDir = transform;

        GameManager.playerReady = true;
    }

    void Update ()
    {
        VectorDetect ();
        CheckMousePointer ();
        Move ();
        Rotate ();
    }

    void VectorDetect ()
    {
        if (mainCameraTransform)
        {
            cameraDir.eulerAngles = new Vector3 (
            mainCameraTransform.eulerAngles.x, mainCameraTransform.eulerAngles.y, mainCameraTransform.eulerAngles.z);
        }
    }

    void CheckMousePointer ()
    {
        Vector2 pointerPosition = cam.ScreenToWorldPoint (pointer.position);
        OnMousePointerMove (pointerPosition);
    }

    void OnMousePointerMove (Vector2 position)
    {

    }

    private void Move ()
    {
        Vector3 velocity = transform.up.normalized * moveSpeed * Time.deltaTime;
        if (Vector3.Distance (velocity, Vector3.zero) > Vector3.Distance (transform.position, V3_moveVector))
            velocity = (V3_moveVector - transform.position) * 0.90f;

        float distance = Vector3.Distance (transform.position + velocity, V3_moveVector);

        if (distance > pointerRadius)
            transform.position += velocity;
    }

    private void Rotate ()
    {
        Vector3 dir = transform.position - V3_moveVector;
        float angle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg + 90;
        transform.rotation = Quaternion.Lerp (
            transform.rotation,
            Quaternion.AngleAxis (angle, Vector3.forward),
            rotateSpeed * Time.deltaTime
        );
    }
}
