using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LitterInit : MonoBehaviour
{
    private LitterArea_Script litterArea;
    private LitterMiniGame[] litterMiniGames;
    public GameObject litterPanel;
    public int count;
    private void OnEnable()
    {
        litterArea = FindObjectOfType<LitterArea_Script>();
        count = 0;
        var allLitter = Resources.FindObjectsOfTypeAll<LitterMiniGame>();
        foreach (LitterMiniGame litter in allLitter)
        {
            litter.gameObject.SetActive(true);
        }
        litterMiniGames = FindObjectsOfType<LitterMiniGame>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (litterMiniGames.Length == count)
        {
            litterPanel.SetActive(false);
            litterArea.Clean();
        }
    }
}
