using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerBostersController : MonoBehaviour
{
    public bool tripleShooting = false;
    public UnityEvent tripleShootingEvent;
    public UnityEvent normalShootingEvent;
    // Start is called before the first frame update

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (tripleShooting == true){
            tripleShootingEvent.Invoke();
        }
        else{
            normalShootingEvent.Invoke();
        }
    }
}
