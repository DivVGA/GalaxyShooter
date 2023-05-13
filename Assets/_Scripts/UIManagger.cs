using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Galxy{
    public class UIManagger : MonoBehaviour
    {
        [SerializeField]
        private Slider _live;
        [SerializeField]
        private Slider _shield;
        [SerializeField]
        private TextMeshProUGUI _txtscore;
        private int _score;

        public int Score
        {
            get 
            { 
                return _score; 
            }
            set
            {
                _score = value;
                _txtscore.text = "SCORE:   " + Score.ToString();
            }
        }

        private void Start() {
            _live.value = 100;    
            Score = 0;
            _txtscore.text = "SCORE:   " + Score.ToString();
            EnemyBehaviour.enemyDead += UpdateScore;
        }
        public void UpdateLive(int value){
            _live.value -= value;
        }

        public void UpdateShield(float value){
            _shield.value = value;
        }

        public void UpdateScore(){
            Score++;
        }
        public void resetScore(){
            this.Score = 0;
        }
        public void resetLife(){
            this._live.value=100;
        }
    }
}
