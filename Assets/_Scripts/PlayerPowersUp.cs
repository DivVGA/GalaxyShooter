using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerPowersUp : MonoBehaviour
{
    // Variable que indica si el disparo triple esta activo
    [SerializeField]
    private bool _tripleShooting = false;
    // Variable que indica si la velocidad aumentada esta activa
    [SerializeField]
    private bool _speed = false;
    [SerializeField]
    private bool _shield = false;
    // Es el tiempo que dura el disparo triple
    [SerializeField]
    private float _powerUpTSTime = 5.0f;
    // Es el tiempo que dura la velocidad aumentada
    [SerializeField]
    private float _powerUpSpTime = 10.0f;
    [SerializeField]
    private float _powerUpShTime = 10.0f;
    // Es el contador de timepo del disparo triple
    [SerializeField]
    private float _timerTS = 0.0f;
    // Es el contador de tiempo de la velocidad aumentada
    [SerializeField]
    private float _timerSp = 0.0f;
    [SerializeField]
    private float _timerSh = 0.0f;
    // Se suscribe lo que pasa en el disparo triple
    public UnityEvent tripleShootingEvent;
    // Se suscribe lo que pasa en el disparo normal
    public UnityEvent normalShootingEvent;
    // Se suscribe lo que pasa en la velocidad aumentanda
    public UnityEvent normalSpeed;
    // Se suscribe lo que pasa en la velocidad normal
    public UnityEvent moreSpeed;

    public UnityEvent shield;
    public UnityEvent noShield;

    // Update is called once per frame
    void Update()
    {
        selectPowerUps();
        counterPowerUps();
    }

    private void changeTripleShoot(){
        this._tripleShooting = true;
        this._timerTS = Time.time + this._powerUpTSTime;
    }

    private void changeSpeed(){
        this._speed = true;
        this._timerSp = Time.time + this._powerUpSpTime;
    }

    private void changeShield(){
        this._shield = true;
        this._timerSh = Time.time + this._powerUpShTime;
    }


    private void counterPowerUps(){
        if (Time.time > this._timerTS){
            this._tripleShooting=false;
        }
        if (Time.time > this._timerSp){
            this._speed=false;
        }
        if (Time.time > this._timerSh){
            this._shield=false;
        }
    }

    private void selectPowerUps(){
        if (_tripleShooting == true){
            tripleShootingEvent?.Invoke();
        }
        else{
            normalShootingEvent?.Invoke();
        }

        if(_speed ==  true){
            moreSpeed?.Invoke();
        }
        else{
            normalSpeed?.Invoke();
        }

        if(_shield ==  true){
            shield?.Invoke();
        }
        else{
            noShield?.Invoke();
        }
    }
    private void OnTriggerEnter(Collider other) {
        if (other.tag=="PowerUps"){
            PowerUp PU = other.GetComponent<PowerUp>();
            
            if (PU){
                int type = PU.GetType();
                if (type == 1){
                    changeTripleShoot();
                }
                else if (type == 2){
                    changeSpeed();
                }
                else if(type == 3){
                    changeShield();
                }
            }
        }
    }
}
