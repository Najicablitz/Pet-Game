using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Cat_Script : MonoBehaviour
{
    [Header("States Bool")]
    public bool isSleeping;
    public bool isEating;
    public bool isThirsty;
    public bool isPeeing;
    public bool isPooping;
    public bool isHungry;
    public bool isDirty;
    public bool isPlaying;
    public bool isSick;

    [Header("Action Bool")]
    public bool feed;
    public bool thirst;
    public bool bathe;
    public bool play;
    public bool pee;
    public bool poop;

    [Header("Parameters")]
    public float _hunger = 50;
    public float _thirst = 50;
    public float _pee = 10;
    public float _poop = 10;
    public float _dirt = 5;
    public float _happiness = 0;
    public float _discipline = 0;
    public float _health;

    [Header("Counters")]
    public float _hungerCtr = 0;
    public float _thirstCtr = 0;
    public float _peeCtr = 0;
    public float _poopCtr = 0;
    public float _cleanCtr = 0;
    public float _playCtr = 0;
    public float _playDisableCtr = 10f;
    public float _disciplineCtr = 0;  

    [Header("Buttons")]
    public Button _feedButton;
    public Button _drinkButton;
    public Button _batheButton;
    public Button _playButton;
    public Button _peeButton;
    public Button _poopButton;

    [Header("Parameter Texts")]
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI hungerText;
    public TextMeshProUGUI thirstText;
    public TextMeshProUGUI peeText;
    public TextMeshProUGUI poopText;
    public TextMeshProUGUI dirtText;
    public TextMeshProUGUI happinessText;
    public TextMeshProUGUI disciplineText;

    [Header("Misc")]
    public Transform _foodArea;
    public Transform _litterArea;
    public Transform _sleepArea;
    public float _speed;
    public TMP_Text _stateText;
    public GameObject _poopInstance;
    public GameObject _peeInstance;
    public FeedArea_Script _feedArea;
    [SerializeField] private List<GameObject> _actionButtons = new List<GameObject>();

    void Update()
    {
        Cat_States();
        Movement_Conditions();
        Discipline();
        Hunger();
        Thirst();
        Pee();
        Poop();
        Play();
        Cleanliness();
        Damage();
        ParameterText();
    }

    void OnMouseDown()
    {
        if(_feedButton.gameObject.activeSelf == false)
        {
            foreach (GameObject panel in _actionButtons)
            {
                panel.SetActive(true);
            }
        }
        else
        {
            foreach (GameObject panel in _actionButtons)
            {
                panel.SetActive(false);
            }
        }
        
    }
    private void Cat_States()
    {
        if (isHungry == false && isThirsty == false && isPeeing == false && isPooping == false && isPlaying == false
            && isSick == false && feed == false && thirst == false && pee == false && poop == false)
        {
            isSleeping = true;
        }
        else
        {
            isSleeping = false;
        }
        if (_hunger <= 20)
        {
            isHungry = true;
            _feedButton.interactable = true;
        }
        else
        {
            isHungry = false;
            _feedButton.interactable = false;
        }
        if (_dirt >= 80)
        {
            isDirty = true;
            _batheButton.interactable = true;
        }
        else
        {
            isDirty = false;
            _batheButton.interactable = false;
        }
        if (_thirst <= 20)
        {
            isThirsty = true;
            _drinkButton.interactable = true;
        }
        else
        {
            isThirsty = false;
            _drinkButton.interactable = false;
        }
        if(_pee >= 80)
        {
            isPeeing = true;
            _peeButton.interactable = true;
        }
        else
        {
            isPeeing = false;
            _peeButton.interactable = false;
        }
        if(_poop >= 80)
        {
            isPooping = true;
            _poopButton.interactable = true;
        }
        else
        {
            isPooping = false;
            _poopButton.interactable = false;
        }
        if(isPlaying == true)
        {
            _playButton.interactable = true;
        }
        else
        {
            _playButton.interactable = false;
        }
    }
    private void Movement_Conditions()
    {
        if (feed == true)
        {
            this.transform.position = Vector2.MoveTowards(transform.position, _foodArea.position, _speed / 2);
            Invoke("EndAction", 3f);
        }
        if (thirst == true)
        {
            this.transform.position = Vector2.MoveTowards(transform.position, _foodArea.position, _speed / 2);
            Invoke("EndAction", 3f);
        }
        if (pee == true)
        {
            this.transform.position = Vector2.MoveTowards(transform.position, _litterArea.position, _speed / 2);
            Invoke("EndAction", 3f);
        }
        if (poop == true)
        {
            this.transform.position = Vector2.MoveTowards(transform.position, _litterArea.position, _speed / 2);
            Invoke("EndAction", 3f);
        }
        if (isSleeping == true)
        {
            this.transform.position = Vector2.MoveTowards(transform.position, _sleepArea.position, _speed / 2);
        }
    }
    private void Discipline()
    {
        if(isHungry == true || isThirsty == true || isPeeing == true || isPooping == true || isPlaying == true)
        {
            _disciplineCtr += Time.deltaTime;
        }
        else
        {
            _disciplineCtr = 0;
        }
        if(_discipline < 0)
        {
            _discipline = 0;
        }
        if(_discipline > 100)
        {
            _discipline = 100;
        }
    }

    void EndAction()
    {
        feed = false;
        thirst = false;
        play = false;
        pee = false;
        poop = false;
    }

    private void ParameterText()
    {
        healthText.text = $"Health: {_health}";
        hungerText.text = $"Hunger: {_hunger}";
        thirstText.text = $"Thirst: {_thirst}";
        peeText.text = $"Pee: {_pee}";
        poopText.text = $"Poop: {_poop}";
        dirtText.text = $"Dirt: {_dirt}";
        happinessText.text = $"Happiness: {_happiness}";
        disciplineText.text = $"Discipline: {_discipline}";
    }

    #region Buttons
    public void FeedButton()
    {
        _hunger += 40;
        _feedArea._feeds -= 40;
        foreach (GameObject panel in _actionButtons)
        {
            panel.SetActive(false);
        }
        feed = true;
        if (_disciplineCtr < 5)
        {
            _discipline += 2;
        }
    }

    public void DrinkButton()
    {
        _thirst += 40;
        _feedArea._water -= 40;
        foreach (GameObject panel in _actionButtons)
        {
            panel.SetActive(false);
        }
        thirst = true;
        if (_disciplineCtr < 5)
        {
            _discipline += 2;
        }
    }
    public void PlayButton()
    {
        _happiness += 5;
        Debug.Log($"Happiness: {_happiness}");
        foreach (GameObject panel in _actionButtons)
        {
            panel.SetActive(false);
        }
        if (_disciplineCtr < 5)
        {
            _discipline += 2;
        }
        isPlaying = false;
        _playDisableCtr = 10;
    }
    public void BatheButton()
    {
        _dirt = 0;
        foreach (GameObject panel in _actionButtons)
        {
            panel.SetActive(false);
        }
    }

    public void PeeButton()
    {
        pee = true;
        _pee = 0;
        foreach (GameObject panel in _actionButtons)
        {
            panel.SetActive(false);
        }
        if (_disciplineCtr < 5)
        {
            _discipline += 2;
        }
    }
    public void PoopButton()
    {
        poop = true;
        _poop = 0;
        foreach (GameObject panel in _actionButtons)
        {
            panel.SetActive(false);
        }
        if (_disciplineCtr < 5)
        {
            _discipline += 2;
        }
    }
    #endregion

    #region Parameters
    public void Hunger()
    {
        _hungerCtr += Time.deltaTime;
        Debug.Log($"HungerCtr: {_hungerCtr}");
        if (_hungerCtr > 5)
        {
            _hunger--;
            _hungerCtr = 0;
        }
        if(_hunger < 0)
        {
            _hunger = 0;
        }
        if (_hunger > 100)
        {
            _hunger = 100;
        }
    }

    public void Thirst()
    {
        _thirstCtr += Time.deltaTime;
        Debug.Log($"ThirstCtr: {_thirstCtr}");
        if (_thirstCtr > 5)
        {
            _thirst++;
            _thirstCtr = 0;
        }
        if(_thirst < 0)
        {
            _thirst = 0;
        }
        if(_thirst > 100)
        {
            _thirst = 100;
        }
    }

    public void Play()
    {
        
        if(isPlaying == false)
        {
            _playCtr -= Time.deltaTime;
        }
        if (_playCtr <= 0)
        {
            isPlaying = true;
            _playCtr = 5;
        }
        if(isPlaying == true)
        {
            _playDisableCtr -= Time.deltaTime;
        }
        if(_playDisableCtr <= 0)
        {
            isPlaying = false;
            _playDisableCtr = 10;
        }
        Debug.Log($"Ctr = {_playDisableCtr}");
        if (_happiness < 0)
        {
            _happiness = 0;
        }
        if(_happiness > 100)
        {
            _happiness = 100;
        }
    }

    public void Pee()
    {
        _peeCtr += Time.deltaTime;
        Debug.Log($"PeeCtr: {_peeCtr}");
        if (_peeCtr > 5)
        {
            _pee++;
            _peeCtr = 0;
        }
        if (_pee >= 100 && _discipline < 50)
        {
            Instantiate(_peeInstance, this.transform.position, Quaternion.identity);
            _pee = 0;
        }

        if(_pee < 0)
        {
            _pee = 0;
        }
        if(_pee > 100)
        {
            _pee = 100;
        }
    }

    public void Poop()
    {
        _poopCtr += Time.deltaTime;
        Debug.Log($"PoopCtr: {_poopCtr}");
        if (_poopCtr > 5)
        {
            _poop++;
            _poopCtr = 0;
        }
        if (_poop >= 100 && _discipline < 50)
        {
            Instantiate(_poopInstance, this.transform.position, Quaternion.identity);
            _poop = 0;
        }
        if(_poop < 0)
        {
            _poop = 0;
        }
        if(_poop > 100)
        {
            _poop = 100;
        }
    }

    public void Cleanliness()
    {
        _cleanCtr += Time.deltaTime;
        Debug.Log($"CleanCtr: {_cleanCtr}");
        if (_cleanCtr > 5)
        {
            _dirt++;
            _cleanCtr = 0;
        }
        if(_dirt < 0)
        {
            _dirt = 0;
        }
        if(_dirt > 100)
        {
            _dirt = 100;
        }
    }

    private void Damage()
    {
        if(_hunger <= 0 || _thirst <= 0 || isSick == true)
        {
            _health -= Time.deltaTime;
        }
        else
        {
            if(_health < 100)
            {
                _health += Time.deltaTime;
            }
        }
        if(_health < 0)
        {
            _health = 0;
        }
        if(_health > 100)
        {
            _health = 100;
        }
    }
    #endregion
}
