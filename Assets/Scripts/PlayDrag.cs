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
    private bool onetime;
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip clip;
    [SerializeField] private Tutorial_Script tutorial;
    private void Awake()
    {
        catParameters = FindObjectOfType<CatParameters>();
        playValue = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Debug.Log(playValue);
        playSlider.value = playValue;
        if(playValue >= 100 && tutorial.tutorial == false)
        {
            playValue = 0;
            catParameters.StopPlaying();
            source.Stop();
        }
    }

    public void OnMouseDrag()
    {
        dragging = true;
        if (Vector2.Distance(transform.position, catParameters.transform.position) < 3 && tutorial.tutorial == false)
        {
            playValue += Time.deltaTime * 20;
            if(onetime == false)
            {
                source.Play();
                onetime = true;
            }
        }

    }

    private void OnMouseUp()
    {
        dragging = false;
        source.Stop();
        onetime = false;
    }
}
