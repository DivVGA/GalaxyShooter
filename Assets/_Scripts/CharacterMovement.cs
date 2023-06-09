using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Galxy{
    public class CharacterMovement : MonoBehaviour
    {
        [SerializeField]
        private float _speed;
        
        private bool InRange(double value, double min, double max){
            if (value >= min && value <= max){
                return true;
            }
            else return false;
        }

        private int DirectionValidator(double num){
            if (num > 0){
                return 1;
            }
            else{
                return -1;
            }
        }

        public void movement(Vector2 mov){
            //Movimiento horizontal
            if (this.tag =="Player"){
                float horizontalMove = mov.x;
                if (InRange(this.transform.position.x, -8.4, 8.4)){
                    this.transform.Translate(new Vector3(horizontalMove, 0, 0) * _speed * Time.deltaTime);
                }
                else{
                    int direction = DirectionValidator(this.transform.position.x);
                    this.transform.position = new Vector3(8.399f*direction, this.transform.position.y,0) ; 
                }

                // Movimineto vertical
                float verticalMove = mov.y; 
                if (InRange(this.transform.position.y, -4.4, 4.4)){
                    this.transform.Translate(new Vector3(0, verticalMove, 0) * _speed * Time.deltaTime);
                }
                else{
                    int direction = DirectionValidator(this.transform.position.y);
                    this.transform.position = new Vector3(this.transform.position.x, 4.399f * direction, 0) ; 
                }
            }
            else{
                float horizontalMove = mov.x;
                float verticalMove = mov.y; 
                this.transform.Translate(new Vector3(horizontalMove, verticalMove, 0) * _speed * Time.deltaTime);
            }
        }

        public void changeSpeed(){
            this._speed=20.0f;
        }
        public void normalSpeed(){
            this._speed=10.0f;
        }
    }

}