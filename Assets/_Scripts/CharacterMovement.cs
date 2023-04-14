using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {   //Movimiento
    }

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

    public void Movement(Vector2 mov){
        //Movimiento horizontal
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

    public void changeSpeed(){
        this._speed=20.0f;
    }
    public void normalSpeed(){
        this._speed=10.0f;
    }
}
