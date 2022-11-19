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

    private float delayCtr = 3f;
    private float disciplineCtr = 5f;
    private bool eating;
    public override void Enter(CatStateManager cat)
    {
        Debug.Log("Hunger State");
        catParameter = Object.FindObjectOfType<CatParameters>();
        currency = Object.FindObjectOfType<Currency_Script>();
        feedArea = Object.FindObjectOfType<FeedArea_Script>();
        time = Object.FindObjectOfType<Time_Manager>();

        animator = catParameter.gameObject.GetComponent<AnimatorScript>();
        direction = Object.FindObjectOfType<Direction>();

        catParameter._feedButton.gameObject.SetActive(true);
        catParameter._feedButton.onClick.AddListener(Eating);
    }
    public override void Exit(CatStateManager cat)
    {
        disciplineCtr = 5f;
        catParameter._feedButton.gameObject.SetActive(false);
        catParameter._feedButton.onClick.RemoveListener(Eating);
        animator.StopWalkAnim(false);
    }
    public override void UpdateLogic(CatStateManager cat)
    {
        disciplineCtr -= Time.deltaTime;
        if (feedArea.GetFeeds < 40)
        {
            catParameter._feedButton.interactable = false;
        }
        else
        {
            catParameter._feedButton.interactable = true;
        }
        if(eating == true)
        {
            var dir = direction.GetAngle(catParameter._foodArea.transform);
            animator.PlayWalkAnim(dir);
            cat.transform.position = Vector2.MoveTowards(cat.transform.position, catParameter._foodArea.transform.position, catParameter._speed / 2);
            delayCtr -= Time.deltaTime;
            if (delayCtr <= 0)
            {
                eating = false;
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
        catParameter._feedButton.gameObject.SetActive(false);
        if (disciplineCtr > 0)
        {
            catParameter._discipline += 5;
        }
    }
}
