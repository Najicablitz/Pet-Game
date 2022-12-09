using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoPlayNoise : MonoBehaviour
{
    private CatStateManager cat;
    private AudioManager audioManager;
    private float ctr;
    private CurrentDay currentDay;
    void Start()
    {
        cat = FindObjectOfType<CatStateManager>();
        audioManager = FindObjectOfType<AudioManager>();
        currentDay = FindObjectOfType<CurrentDay>();
        ctr = Random.Range(8, 16);
    }

    // Update is called once per frame
    void Update()
    {
        if(currentDay.pause == false)
        {
            if (ctr <= 0 && cat.currentState != cat.sleepState)
            {
                PlaySound();
                ctr = Random.Range(8, 16);
            }
            else
            {
                ctr -= Time.deltaTime;
            }
        }        
    }

    private void PlaySound()
    {
        audioManager.PlayPurr();
    }
}
