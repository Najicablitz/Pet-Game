using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadGameScene : MonoBehaviour
{
    private GameManager gameManager;
    [SerializeField] private Button button;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        button.onClick.AddListener(Load_GameScene);
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void Load_GameScene()
    {
        gameManager.Load_Level();
    }
}
