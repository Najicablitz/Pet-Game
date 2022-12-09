using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkipTutorial : MonoBehaviour
{
    Tutorial_Script[] tutorial_Scripts;
    TutorialBegin[] tutorialBegins;
    Button button;
    private GameManager gameManager;
    public bool tutorial;
    public GameObject bubble;
    void Start()
    {
        tutorial_Scripts = Resources.FindObjectsOfTypeAll<Tutorial_Script>();
        tutorialBegins = Resources.FindObjectsOfTypeAll<TutorialBegin>();
        gameManager = FindObjectOfType<GameManager>();
        if(gameManager.load == true)
        {
            tutorial = false;
        }
        if (tutorial == true)
        {
            gameObject.SetActive(true);
        }
    }

    public void Skip()
    {
        foreach(Tutorial_Script script in tutorial_Scripts)
        {
            script.tutorial = false;
        }
        foreach (TutorialBegin script in tutorialBegins)
        {
            script.tutorial = false;
        }
        bubble.SetActive(false);
    }
}
