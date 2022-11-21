using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultState : BaseState
{
    CatParameters catParameter;
    Time_Manager time;

    AnimatorScript animator;
    Direction direction;

    private float _sleepCtr = 20f; 
    public override void Enter(CatStateManager cat)
    {
        Debug.Log("Default State");
        catParameter = Object.FindObjectOfType<CatParameters>();
        time = Object.FindObjectOfType<Time_Manager>();

        animator = catParameter.gameObject.GetComponent<AnimatorScript>();
        direction = Object.FindObjectOfType<Direction>();

        //animator.amt.SetTrigger("idle");
    }
    public override void Exit(CatStateManager cat)
    {
        catParameter._batheButton.gameObject.SetActive(false);
        catParameter._playButton.gameObject.SetActive(false);
        catParameter._cureButton.gameObject.SetActive(false);
        animator.amt.SetBool("play", false);
        animator.StopWalkAnim(false);
    }
    public override void UpdateLogic(CatStateManager cat)
    {
        var centerAreaPos =  catParameter._centerArea.transform.position;        
        if(cat.transform.position != centerAreaPos)
        {
            animator.PlayWalkAnim(direction.GetAngle(catParameter._sleepArea.transform));
        }
        else
        {
            animator.StopWalkAnim(false);
        }
        cat.transform.position = Vector2.MoveTowards(cat.transform.position, centerAreaPos, catParameter._speed / 2);


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
                animator.amt.SetBool("play", true);
                catParameter._playButton.gameObject.SetActive(true);
            }
            else
            {
                animator.amt.SetBool("play", false);
                catParameter._playButton.gameObject.SetActive(false);
            }
            if (catParameter.isSick == true)
            {
                catParameter._cureButton.gameObject.SetActive(true);
            }
            _sleepCtr -= Time.deltaTime;
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
