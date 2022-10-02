using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DigitalClock : MonoBehaviour
{
    Time_Manager tm;
    public TextMeshProUGUI display;
    void Start()
    {
        tm = FindObjectOfType<Time_Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        display.text = tm.Clock12Hour();
    }
}
