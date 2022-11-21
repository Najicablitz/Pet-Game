using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RenderScript : MonoBehaviour
{
    public Camera MainCamera;
    public Canvas interasctions;
    public GameObject checkPos;
    public Transform right;
    public Transform left;
    private Vector2 screenBounds;
    // Use this for initialization
    void Start()
    {
        screenBounds = MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, MainCamera.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 v2 = checkPos.transform.position;
        if (screenBounds.x < v2.x || screenBounds.y < v2.y)
        {
            interasctions.transform.position = left.transform.position;
        }
        else if(screenBounds.x > v2.x || screenBounds.y > v2.y)
        {
            interasctions.transform.position = right.transform.position;
        }
    }
}
