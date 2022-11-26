using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayDrag : MonoBehaviour
{
    public Slider playSlider;
    CatParameters catParameters;
    private float playValue;
    public bool dragging;
    private void Awake()
    {
        catParameters = FindObjectOfType<CatParameters>();
        playValue = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log(playValue);
        playSlider.value = playValue;
        if(playValue >= 100)
        {
            catParameters.Playing();
        }
    }

    public void OnMouseDrag()
    {
        dragging = true;
        if (Vector2.Distance(transform.position, catParameters.transform.position) < 3)
        {
            playValue += Time.deltaTime * 20;
        }

    }

    private void OnMouseUp()
    {
        dragging = false;
    }
}
