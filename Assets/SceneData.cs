using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SceneData
{
    public float health;
    public float hunger;
    public float thirst;
    public float pee;
    public float poop;
    public float dirt;
    public float happiness;
    public float discipline;
    public bool sick;

    public float day;
    public float feeds;
    public float water;
    public float litter;
    public bool skipTutorial;
    public bool[] beginTutorial;
    public bool[] tutorialScript;

    public float[] position;

    public SceneData(CatParameters catParameters, FeedArea_Script feedArea, LitterArea_Script litterArea,
        Time_Manager tm)
    {
        health = catParameters._health;
        hunger = catParameters._hunger;
        thirst = catParameters._thirst;
        pee = catParameters._pee;
        poop = catParameters._poop;
        dirt = catParameters._dirt;
        happiness = catParameters._happiness;
        discipline = catParameters._discipline;
        sick = catParameters.isSick;

        day = tm._totalTime;
        feeds = feedArea.GetFeeds;
        water = feedArea.GetWater;
        litter = litterArea.GetFill;

        position = new float[3];
        position[0] = catParameters.transform.position.x;
        position[1] = catParameters.transform.position.y;
        position[2] = catParameters.transform.position.z;
    }
}
