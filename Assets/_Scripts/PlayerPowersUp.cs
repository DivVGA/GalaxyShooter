using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerPowersUp : MonoBehaviour
{
    [SerializeField]
    private bool _tripleShooting = false;
    public UnityEvent tripleShootingEvent;
    public UnityEvent normalShootingEvent;
    private float _powerUpTSTimer = 5.0f;
    private float _timer = 0.0f;
    private float _actualPUTimer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        counterPowerUp();
        selectShot();
    }

    private void changeTripleShoot(){
        this._tripleShooting = true;
        this._timer = Time.time + this._powerUpTSTimer;
        // this._actualPUTimer = this._powerUpTSTimer;
        // StartCoroutine("playerPowerUpTimer");
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag=="PowerUps"){
            if (other.name == "Triple_Shot_PowerUp(Clone)"){
                changeTripleShoot();
            }
        }
    }

    private void counterPowerUp(){
        if (Time.time > this._timer){
            this._tripleShooting=false;
        }
    }

    private void selectShot(){
        if (_tripleShooting == true){
            tripleShootingEvent?.Invoke();
        }
        else{
            normalShootingEvent?.Invoke();
        }
    }

    // IEnumerator playerPowerUpTimer(){
    //     yield return new WaitForSeconds(_actualPUTimer);
    //     _tripleShooting = false;
    // }
}
