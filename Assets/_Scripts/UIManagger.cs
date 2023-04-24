using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManagger : MonoBehaviour
{
    [SerializeField]
    private Slider _live;
    [SerializeField]
    private Slider _shield;
    [SerializeField]
    private TextMeshProUGUI _txtscore;
    private int _score;


    private void Start() {
        _live.value = 100;    
        _score = 0;
        _txtscore.text = "SCORE:   " + _score.ToString();
    }
    public void UpdateLive(int value){
        _live.value -= value;
    }

    public void UpdateShield(float value){
        _shield.value = value;
    }

    public void UpdateScore(){
        _score++;
        _txtscore.text = "SCORE:   " + _score.ToString();
    }
}
