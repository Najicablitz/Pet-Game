using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultState : BaseState
{
    CatParameters catParameter;
    PlayDrag playDrag;
    Time_Manager time;

    AnimatorScript animator;
    AudioManager audioManager;
    Direction direction;

    Vector3 random;
    bool randomAssign;
    bool roam;
    bool onetime;

    private float _sleepCtr = 20f;
    private float _roamCtr = 5f;
    public override void Enter(CatStateManager cat)
    {
        Debug.Log("Default State");
        catParameter = Object.FindObjectOfType<CatParameters>();
        time = Object.FindObjectOfType<Time_Manager>();

        animator = catParameter.gameObject.GetComponent<AnimatorScript>();
        animator.amt.SetBool("sleep", false);
        audioManager = Object.FindObjectOfType<AudioManager>();
        direction = Object.FindObjectOfType<Direction>();
        random = Vector3.zero;
        randomAssign = false;
        onetime = false;
        _roamCtr = Random.Range(5, 8);
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
        Debug.Log("Roam: "+roam);
        Debug.Log("Play: " + catParameter.isPlaying);
        if (_roamCtr <= 0 && catParameter.playState == false && catParameter.bathe == false) {
            roam = true;
            if(randomAssign == false)
            {
                random = Random.insideUnitCircle * 3;
                if (random.y > 0.8 || random.x > 6.8)
                {
                    Debug.Log("Border");
                    random = Random.insideUnitCircle * 3;
                }
                else 
                {
                    randomAssign = true;
                }
            }
            RoamAI();
        }
        else if(catParameter.playState == false && catParameter.bathe == false)
        {
            _roamCtr -= Time.deltaTime;
            roam = false;
        }

        #region Change States
        if ((catParameter._hunger <= 20 || (time.Hour > 6 && time.Hour < 7)) && catParameter.playState != true)
        {
            cat.ChangeState(cat.hungerState);
        }
        if (catParameter._thirst <= 20 && catParameter.playState != true)
        {
            cat.ChangeState(cat.thirstState);
        }
        if (catParameter._pee >= 80 && catParameter.playState != true)
        {
            cat.ChangeState(cat.peeState);
        }
        if (catParameter._poop >= 80 && catParameter.playState != true)
        {
            cat.ChangeState(cat.pooState);
        }
        #endregion

        if (cat.currentState == cat.defaultState && cat.dragging == false)
        {
            if (catParameter._dirt >= 80 && catParameter.playState == false && roam == false)
            {
                catParameter._batheButton.gameObject.SetActive(true);
            }
            else if (catParameter._dirt < 80 || catParameter.playState == true || roam == true)
            {
                catParameter._batheButton.gameObject.SetActive(false);
            }
            if (catParameter.isPlaying == true && catParameter.bathe == false && roam == false && catParameter.isSick == false)
            {
                animator.amt.SetBool("play", true);
                if (onetime == false)
                {
                    catParameter._playButton.gameObject.SetActive(true);
                    onetime = true;
                }
            }
            else
            {
                onetime = false;
                animator.amt.SetBool("play", false);
                catParameter._playButton.gameObject.SetActive(false);
            }
            if (catParameter.isSick == true && catParameter.playState == false && catParameter.bathe == false)
            {
                catParameter._cureButton.gameObject.SetActive(true);
            }
            else
            {
                catParameter._cureButton.gameObject.SetActive(false);
            }
            if(catParameter.playState == false && catParameter.bathe == false)
            {
                _sleepCtr -= Time.deltaTime;
            }
            if (_sleepCtr <= 0)
            {
                cat.ChangeState(cat.sleepState);
                _sleepCtr = Random.Range(5,10);
            }
        }
       
    }
    public override void UpdatePhysics(CatStateManager cat)
    {
        throw new System.NotImplementedException();
    }

    private void RoamAI()
    {
        if (roam == true)
        {
            animator.PlayWalkAnim(direction.GetAngle(random));
            catParameter.transform.position = Vector2.MoveTowards(catParameter.transform.position, random, catParameter._speed * Time.deltaTime);
        }
        else
        {
            animator.StopWalkAnim(false);
            roam = false;
            catParameter.transform.position = Vector3.zero;
        }
        if(catParameter.transform.position == random)
        {
            animator.StopWalkAnim(false);
            random = Vector3.zero;
            _roamCtr = 5;
            randomAssign = false;
            roam = false;
        }
    }
}
