using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LitterMiniGame : MonoBehaviour, IPointerDownHandler
{
    public LitterInit litterInit;
    public void OnPointerDown(PointerEventData eventData)
    {
        gameObject.SetActive(false);
        litterInit.count++;
    }
}
