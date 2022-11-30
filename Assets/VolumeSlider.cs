using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private Slider slider;
    void Awake()
    {
        AudioManager.Instance.ChangeMasterVolume(slider.value);
        slider.onValueChanged.AddListener(val => AudioManager.Instance.ChangeMasterVolume(val));
    }

    // Update is called once per frame
    void Update()
    {
    }
}
