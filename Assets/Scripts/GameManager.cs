using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Load_Level()
    {
        
        SceneManager.LoadScene("GameScene");
    }

    public void Load_Menu()
    {
        
        SceneManager.LoadScene("StartMenuScene");
    }

    public void Load_Post_Game()
    {

        SceneManager.LoadScene("Post-Game");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
