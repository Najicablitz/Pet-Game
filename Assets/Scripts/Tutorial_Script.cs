using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_Script : MonoBehaviour
{
    private CurrentDay currentDay;
    public List<GameObject> tutorialObject;
    public GameObject textBubble;
    public bool tutorial;
    private GameManager gameManager;
    private void Awake()
    {
        currentDay = FindObjectOfType<CurrentDay>();
        gameManager = FindObjectOfType<GameManager>();
        if (gameManager.load == true)
        {
            tutorial = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach(GameObject gameObject in tutorialObject)
        {
            if (gameObject.activeSelf && tutorial == true)
            {
                currentDay.pause = true;
                textBubble.SetActive(true);
            }
        }
        
    }

    public void CloseTutorial()
    {
        tutorial = false;
        textBubble.SetActive(false);
        currentDay.pause = false;
    }
}
