using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedArea_Script : MonoBehaviour
{
    public float _feeds;
    public float _water;
    public GameObject _refillButton;
    private void OnMouseDown()
    {
        _refillButton.SetActive(true);
    }

    public void Refill()
    {
        _water = 100;
        _feeds = 100;
        _refillButton.SetActive(false);
    }
}
