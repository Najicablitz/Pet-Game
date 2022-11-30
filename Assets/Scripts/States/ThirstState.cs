using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirstState : BaseState
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
    private bool drinking;
    private bool onetime;
    public override void Enter(CatStateManager cat)
    {
        Debug.Log("Thirst State");
        catParameter = Object.FindObjectOfType<CatParameters>();
        currency = Object.FindObjectOfType<Currency_Script>();
        feedArea = Object.FindObjectOfType<FeedArea_Script>();
        time = Object.FindObjectOfType<Time_Manager>();

        animator = catParameter.gameObject.GetComponent<AnimatorScript>();
        direction = Object.FindObjectOfType<Direction>();
        audioManager = Object.FindObjectOfType<AudioManager>();
        audioManager.PlayPurr();

        catParameter._drinkAction.gameObject.SetActive(true);
        //catParameter._drinkAction.onClick.AddListener(Drinking);
        onetime = false;
    }
    public override void Exit(CatStateManager cat)
    {
        disciplineCtr = 5f;
        catParameter._drinkAction.gameObject.SetActive(false);
        //catParameter._drinkAction.onClick.RemoveListener(Drinking);
        animator.StopWalkAnim(false);
        drinking = false;
    }
    public override void UpdateLogic(CatStateManager cat)
    {
        if (cat.GetFeeds() == true)
        {
            if (onetime == false)
            {
                Drinking();
                audioManager.PlayDrink();
                onetime = true;
            }
        }
        disciplineCtr -= Time.deltaTime;
        /*if (feedArea.GetWater < 40)
        {
            catParameter._drinkButton.interactable = false;
        }
        else
        {
            catParameter._drinkButton.interactable = true;
        }*/
        if (drinking == true)
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
        if (catParameter._thirst > 20 && time.Hour > 7)
        {
            cat.ChangeState(cat.defaultState);
        }
    }
    public override void UpdatePhysics(CatStateManager cat)
    {

    }

    private void Drinking()
    {
        if(feedArea.GetWater >= 40) 
        {
            catParameter._thirst += 40;
            currency.GetCurrency -= 20;
            feedArea.GetWater -= 40;
            drinking = true;
            catParameter._drinkAction.gameObject.SetActive(false);
            if (disciplineCtr > 0)
            {
                catParameter._discipline += 5;
            }
        }
        
    }
}
