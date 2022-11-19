using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PooState : BaseState
{
    CatParameters catParameter;
    LitterArea_Script litterArea;
    private float delayCtr = 3f;
    private float disciplineCtr = 5f;
    private bool pooping;
    public override void Enter(CatStateManager cat)
    {
        Debug.Log("Poop State");
        catParameter = Object.FindObjectOfType<CatParameters>();
        litterArea = Object.FindObjectOfType<LitterArea_Script>();
        catParameter._poopButton.gameObject.SetActive(true);
        catParameter._poopButton.onClick.AddListener(Pooping);
    }
    public override void Exit(CatStateManager cat)
    {
        disciplineCtr = 5f;
        catParameter._poopButton.gameObject.SetActive(false);
        catParameter._poopButton.onClick.RemoveListener(Pooping);
    }
    public override void UpdateLogic(CatStateManager cat)
    {
        disciplineCtr -= Time.deltaTime;
        if (litterArea.GetFill >= 100)
        {
            catParameter._poopButton.interactable = false;
        }
        else
        {
            catParameter._poopButton.interactable = true;
        }
        if (catParameter._poop >= 100 && catParameter._discipline < 50 && pooping == false)
        {
            GameObject instanceObj = Object.Instantiate(catParameter._poopInstance,
                                    catParameter.gameObject.transform.position, Quaternion.identity) as GameObject;
            catParameter._poop = 0;
            cat.ChangeState(cat.defaultState);
        }
        else if(litterArea.GetFill < 100)
        {
            if (catParameter._poop >= 100 && catParameter._discipline >= 50 || pooping == true)
            {
                cat.transform.position = Vector2.MoveTowards(
                                         cat.transform.position, catParameter._litterArea.position, catParameter._speed / 2);

                delayCtr -= Time.deltaTime;
                if (delayCtr <= 0)
                {
                    catParameter._poop = 0;
                    pooping = false;
                    delayCtr = 3f;
                    cat.ChangeState(cat.defaultState);
                }
            }
        }
         
    }
    public override void UpdatePhysics(CatStateManager cat)
    {

    }
    private void Pooping()
    {
        pooping = true;
        litterArea.GetFill += 40;
        catParameter._poopButton.gameObject.SetActive(false);
        if (disciplineCtr > 0)
        {
            catParameter._discipline += 5;
        }
    }
}
