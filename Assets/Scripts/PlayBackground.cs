using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBackground : MonoBehaviour
{
    private AudioManager audioManager;
    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        audioManager.PlayBackground();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
