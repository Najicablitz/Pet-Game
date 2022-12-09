using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialBegin : MonoBehaviour
{
    public List<GameObject> tutorials = new List<GameObject>();
    private int index;
    public bool tutorial;
    CurrentDay currentDay;
    private GameManager gameManager;
    void Start()
    {
        currentDay = FindObjectOfType<CurrentDay>();
        index = 0;
        gameManager = FindObjectOfType<GameManager>();
        if (gameManager.load == true)
        {
            tutorial = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(tutorial == true)
        {
            currentDay.pause = true;
            tutorials[index].SetActive(true);
        }
        Debug.Log("Index: " + index);
        Debug.Log("tutorials.Count: " + tutorials.Count);
    }

    public void Next()
    {
        if(tutorials.Count != index + 1)
        {
            tutorials[index].SetActive(false);
            index++;
            tutorials[index].SetActive(true);
        }
        else
        {
            tutorials[index].SetActive(false);
            tutorial = false;
            currentDay.pause = false;
        }
    }
}
