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

    private float delayCtr = 3f;
    private float disciplineCtr = 5f;
    private bool drinking;
    public override void Enter(CatStateManager cat)
    {
        Debug.Log("Hunger State");
        catParameter = Object.FindObjectOfType<CatParameters>();
        currency = Object.FindObjectOfType<Currency_Script>();
        feedArea = Object.FindObjectOfType<FeedArea_Script>();
        time = Object.FindObjectOfType<Time_Manager>();

        animator = catParameter.gameObject.GetComponent<AnimatorScript>();
        direction = Object.FindObjectOfType<Direction>();

        catParameter._drinkButton.gameObject.SetActive(true);
        catParameter._drinkButton.onClick.AddListener(Drinking);
    }
    public override void Exit(CatStateManager cat)
    {
        disciplineCtr = 5f;
        catParameter._drinkButton.gameObject.SetActive(false);
        catParameter._drinkButton.onClick.RemoveListener(Drinking);
        animator.StopWalkAnim(false);
        drinking = false;
    }
    public override void UpdateLogic(CatStateManager cat)
    {
        disciplineCtr -= Time.deltaTime;
        if (feedArea.GetWater < 40)
        {
            catParameter._drinkButton.interactable = false;
        }
        else
        {
            catParameter._drinkButton.interactable = true;
        }
        if (drinking == true)
        {
            var dir = direction.GetAngle(catParameter._foodArea.transform);
            animator.PlayWalkAnim(dir);
            cat.transform.position = Vector2.MoveTowards(cat.transform.position, catParameter._foodArea.transform.position, catParameter._speed / 2);
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
        catParameter._thirst += 40;
        currency.GetCurrency -= 20;
        feedArea.GetWater -= 40;
        drinking = true;
        catParameter._drinkButton.gameObject.SetActive(false);
        if (disciplineCtr > 0)
        {
            catParameter._discipline += 5;
        }
    }
}
