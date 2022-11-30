using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CurrentDay : MonoBehaviour
{
    public Time_Manager tm;
    public GameObject panel;
    public float _currentday;
    public TextMeshProUGUI text;
    public bool pause;
    private float ctr;
    void Start()
    {
        //tm = FindObjectOfType<Time_Manager>();
        ctr = 3;        
    }

    // Update is called once per frame
    void Update()
    {      
        if(_currentday < tm._days)
        {
            panel.SetActive(true);
            pause = true;
            text.text = "Day: " + tm._days.ToString();
            ctr -= Time.deltaTime;
            if (ctr <= 0)
            {
                panel.SetActive(false);
                _currentday = tm._days;
                ctr = 3;
                pause = false;
            }
        }        
    }
}
