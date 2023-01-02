using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBackground : MonoBehaviour
{
    private AudioManager audioManager;
    [SerializeField] private AudioClip clip;    
    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        audioManager.PlayBackground(clip);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
