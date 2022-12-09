using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DropFeeds : MonoBehaviour, IDropHandler
{
    private FeedArea_Script feedArea;
    private RefillMiniGame[] feeds;
    public GameObject feedMiniGame;
    public int count;
    private AudioManager audioManager;
    private void OnEnable()
    {
        feedArea = FindObjectOfType<FeedArea_Script>();
        audioManager = FindObjectOfType<AudioManager>();
        count = 0;
        var allFeeds = Resources.FindObjectsOfTypeAll<RefillMiniGame>();        
        foreach (RefillMiniGame feed in allFeeds)
        {
            feed.gameObject.SetActive(true);
        }
        feeds = FindObjectsOfType<RefillMiniGame>();
        Debug.Log("Test");
    }

    public void OnDrop(PointerEventData eventData)
    {
        eventData.pointerDrag.SetActive(false);
        feedArea.GetFeeds += 20;
        feedArea.GetWater += 20;
        audioManager.PlayRefill();
        count++;
    }

    private void Update()
    {
      
        if(feeds.Length == count)
        {
            feedMiniGame.SetActive(false);
        }
        
        Debug.Log(feeds.Length);
    }

}
