using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HungerState : BaseState
{
    CatParameters catParameter;
    Currency_Script currency;
    FeedArea_Script feedArea;
    Time_Manager time;

    AnimatorScript animator;
    Direction direction;
    AudioManager audioManager;

    private float delayCtr = 3f;
    private float disciplineCtr = 5f;
    private bool eating;
    private bool onetime;
    public override void Enter(CatStateManager cat)
    {
        Debug.Log("Hunger State");
        catParameter = Object.FindObjectOfType<CatParameters>();
        currency = Object.FindObjectOfType<Currency_Script>();
        feedArea = Object.FindObjectOfType<FeedArea_Script>();
        time = Object.FindObjectOfType<Time_Manager>();

        animator = catParameter.gameObject.GetComponent<AnimatorScript>();
        direction = Object.FindObjectOfType<Direction>();
        audioManager = Object.FindObjectOfType<AudioManager>();
        audioManager.PlayPurr();

        catParameter._feedAction.gameObject.SetActive(true);
        //catParameter._feedAction.onClick.AddListener(Eating);
        onetime = false;
    }
    public override void Exit(CatStateManager cat)
    {
        disciplineCtr = 5f;
        catParameter._feedAction.gameObject.SetActive(false);
        //catParameter._feedAction.onClick.RemoveListener(Eating);
        animator.StopWalkAnim(false);
        eating = false;
    }
    public override void UpdateLogic(CatStateManager cat)
    {
        if (cat.GetFeeds() == true)
        {
            if (onetime == false)
            {
                Eating();
                onetime = true;
            }
        }
        disciplineCtr -= Time.deltaTime;
        /*if (feedArea.GetFeeds < 40)
        {
            catParameter._feedButton.interactable = false;
        }
        else
        {
            catParameter._feedButton.interactable = true;
        }*/
        if(eating == true)
        {
            if (Vector2.Distance(cat.transform.position, catParameter._foodArea.position) > 3)
            {
                var dir = direction.GetAngle(catParameter._foodArea.transform);
                animator.PlayWalkAnim(dir);
                cat.transform.position = Vector2.MoveTowards(cat.transform.position, catParameter._foodArea.transform.position, catParameter._speed / 2);
            }
            else
            {
                animator.StopWalkAnim(false);
            }
            delayCtr -= Time.deltaTime;
            if (delayCtr <= 0)
            {
                delayCtr = 3f;
                cat.ChangeState(cat.defaultState);
            }
        }
        if(catParameter._hunger > 20 && time.Hour > 7)
        {
            cat.ChangeState(cat.defaultState);
        }
    }
    public override void UpdatePhysics(CatStateManager cat)
    {
        
    }

    private void Eating()
    {
        catParameter._hunger += 40;
        currency.GetCurrency -= 20;
        feedArea.GetFeeds -= 40;
        eating = true;
        catParameter._feedAction.gameObject.SetActive(false);
        if (disciplineCtr > 0)
        {
            catParameter._discipline += 5;
        }
    }
}
