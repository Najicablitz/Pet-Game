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
    private TutorialBegin tutorialBegin;
    private GameManager gameManager;
    void Start()
    {
        //tm = FindObjectOfType<Time_Manager>();
        ctr = 3;
        tutorialBegin = FindObjectOfType<TutorialBegin>();
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {   
        if(tutorialBegin.tutorial == false)
        {
            if (_currentday < tm._days)
            {
                //gameManager.Save();

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
                    gameManager.Save();
                }
            }
        }        
    }
}
