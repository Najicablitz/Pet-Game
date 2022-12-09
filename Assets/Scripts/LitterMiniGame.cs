using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LitterMiniGame : MonoBehaviour, IPointerDownHandler
{
    public LitterInit litterInit;
    private AudioManager audioManager;

    private void OnEnable()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        audioManager.PlayClean();
        gameObject.SetActive(false);
        litterInit.count++;
    }
}
