using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultState : BaseState
{
    CatParameters catParameter;
    Time_Manager time;

    AnimatorScript animator;
    Direction direction;

    private float _sleepCtr = 5f; 
    public override void Enter(CatStateManager cat)
    {
        Debug.Log("Default State");
        catParameter = Object.FindObjectOfType<CatParameters>();
        time = Object.FindObjectOfType<Time_Manager>();

        animator = catParameter.gameObject.GetComponent<AnimatorScript>();
        direction = Object.FindObjectOfType<Direction>();
    }
    public override void Exit(CatStateManager cat)
    {
        catParameter._batheButton.gameObject.SetActive(false);
        catParameter._playButton.gameObject.SetActive(false);
        catParameter._cureButton.gameObject.SetActive(false);
    }
    public override void UpdateLogic(CatStateManager cat)
    {
        cat.transform.position = Vector2.MoveTowards(cat.transform.position, catParameter._sleepArea.transform.position, catParameter._speed / 2);
        if (catParameter._hunger <= 20 || (time.Hour > 6 && time.Hour < 7))
        {
            cat.ChangeState(cat.hungerState);
        }
        if (catParameter._thirst <= 20)
        {
            cat.ChangeState(cat.thirstState);
        }
        if (catParameter._pee >= 80)
        {
            cat.ChangeState(cat.peeState);
        }
        if (catParameter._poop >= 80)
        {
            cat.ChangeState(cat.pooState);
        }
        if(cat.currentState == cat.defaultState)
        {
            //animator.DefaultAnim();
            if (catParameter._dirt >= 80)
            {
                catParameter._batheButton.gameObject.SetActive(true);
            }
            else if (catParameter._dirt < 80)
            {
                catParameter._batheButton.gameObject.SetActive(false);
            }
            if (catParameter.isPlaying == true)
            {
                catParameter._playButton.gameObject.SetActive(true);
            }
            else
            {
                catParameter._playButton.gameObject.SetActive(false);
            }
            if (catParameter.isSick == true)
            {
                catParameter._cureButton.gameObject.SetActive(true);
            }
            //_sleepCtr -= Time.deltaTime;
            if(_sleepCtr <= 0)
            {
                cat.ChangeState(cat.sleepState);
                _sleepCtr = 5f;
            }
        }
       
    }
    public override void UpdatePhysics(CatStateManager cat)
    {
        throw new System.NotImplementedException();
    }

    
}
