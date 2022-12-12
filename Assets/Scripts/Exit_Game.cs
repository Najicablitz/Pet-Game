using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit_Game : MonoBehaviour
{
    private GameManager gameManager;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Exit()
    {
        gameManager.Exit();
    }
}
