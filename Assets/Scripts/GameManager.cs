using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private CatParameters catParameters;
    [SerializeField] private FeedArea_Script feedArea;
    [SerializeField] private LitterArea_Script litterArea;
    [SerializeField] private Time_Manager tm;
    public bool load;
    private bool onetime;
    private void Awake()
    {
        Debug.Log("Awake");
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        SceneManager.activeSceneChanged += ChangedActiveScene;

        if (load == true)
        {
            Data();
        }
    }

    private void ChangedActiveScene(Scene current, Scene next)
    {
        catParameters = FindObjectOfType<CatParameters>();
        if (catParameters == null)
        {
            catParameters = null;
        }
        feedArea = FindObjectOfType<FeedArea_Script>();
        if (feedArea == null)
        {
            feedArea = null;
        }
        litterArea = FindObjectOfType<LitterArea_Script>();
        if (litterArea == null)
        {
            litterArea = null;
        }
        tm = FindObjectOfType<Time_Manager>();
        if (tm == null)
        {
            tm = null;
        }        
    }

    public void Save()
    {
        Debug.Log("Save");
        SaveLoad.OnSave(catParameters,feedArea,litterArea,tm);
    }
    public void Load()
    {
        load = true;

        SceneManager.LoadScene("GameScene");
    }

    public void Data()
    {
        SceneData data = SaveLoad.OnLoad();
        catParameters._health = data.health;
        catParameters._hunger = data.hunger;
        catParameters._thirst = data.thirst;
        catParameters._pee = data.pee;
        catParameters._poop = data.poop;
        catParameters._dirt = data.dirt;
        catParameters._happiness = data.happiness;
        catParameters._discipline = data.discipline;
        catParameters.isSick = data.sick;

        tm._totalTime = data.day;
        feedArea.GetFeeds = data.feeds;
        feedArea.GetWater = data.water;
        litterArea.GetFill = data.litter;

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        catParameters.transform.position = position;
    }
    public void Load_Level()
    {
        load = false;
        SceneManager.LoadScene("GameScene");
    }
    public void Resume()
    {
        SceneManager.LoadScene("GameScene");
        Load();
    }

    public void Load_Menu()
    {
        
        SceneManager.LoadScene("StartMenuScene");
    }

    public void Load_Post_Game()
    {

        SceneManager.LoadScene("EndScene");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
