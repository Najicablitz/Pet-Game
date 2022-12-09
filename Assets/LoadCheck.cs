using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCheck : MonoBehaviour
{
    GameManager gameManager;
    private void Awake()
    {
        
    }
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        if (gameManager.load == true)
        {
            gameManager.Data();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
