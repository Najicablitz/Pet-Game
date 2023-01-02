using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_Litter : MonoBehaviour
{
    AudioManager audioManager;
    private void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }
    private void OnMouseDown()
    {
        Debug.Log("Destroy");
        Destroy(this.gameObject);
    }
}
