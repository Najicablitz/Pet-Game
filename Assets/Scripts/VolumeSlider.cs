using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private Slider masterSlider;
    [SerializeField] private Slider sfxSlider;
    [SerializeField] private Slider btnSlider;
    [SerializeField] private AudioSource sfx;
    [SerializeField] private AudioSource bg;
    AudioManager audioManager;
    private void OnEnable()
    {
        audioManager = FindObjectOfType<AudioManager>();
        bg = audioManager.BG;
        sfx = audioManager.SFX;
        masterSlider.value = AudioListener.volume;
        btnSlider.value = bg.volume;
        sfxSlider.value = sfx.volume;
    }
    void Awake()
    {
       /* AudioManager.Instance.ChangeMasterVolume(masterSlider.value);
        masterSlider.onValueChanged.AddListener(val => AudioManager.Instance.ChangeMasterVolume(val));*/
        
    }

    // Update is called once per frame
    void Update()
    {
        AudioListener.volume = masterSlider.value;
        bg.volume = btnSlider.value;
        sfx.volume = sfxSlider.value;
    }
}
