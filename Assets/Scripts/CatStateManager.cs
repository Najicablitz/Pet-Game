using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatStateManager : MonoBehaviour
{
    BaseState currentState;
    DefaultState defaultState = new DefaultState();
    HungerState hungerState = new HungerState();
    ThirstState thirstState = new ThirstState();
    PeeState peeState = new PeeState();
    PooState pooState = new PooState();
    SleepState sleepState = new SleepState();
    PlayState playState = new PlayState();
    SickState sickState = new SickState();
    void Start()
    {
        currentState = defaultState;
        currentState.Enter(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateLogic(this);
    }
}
