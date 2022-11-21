using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CatStateManager : MonoBehaviour
{
    public BaseState currentState;
    public DefaultState defaultState = new DefaultState();
    public HungerState hungerState = new HungerState();
    public ThirstState thirstState = new ThirstState();
    public PeeState peeState = new PeeState();
    public PooState pooState = new PooState();
    public SleepState sleepState = new SleepState();
    public PlayState playState = new PlayState();
    public SickState sickState = new SickState();
        
    void Start()
    {
        currentState = defaultState;
        currentState.Enter(this); 
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Current State: " + currentState);
        currentState.UpdateLogic(this);       
    }

    public void ChangeState(BaseState state)
    {
        currentState.Exit(this);
        currentState = state;
        state.Enter(this);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Feeds")
        {
            Debug.Log("Hit Feeds");
            ChangeState(defaultState);
        }
        if (collision.tag == "Litter")
        {
            Debug.Log("Hit Litter");
            ChangeState(defaultState);
        }
    }
}
