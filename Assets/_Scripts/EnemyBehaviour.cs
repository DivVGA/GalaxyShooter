using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField]
    private UnityEvent<Vector2> enemyMoving;
    private float yDirection = -1;
    [SerializeField]
    private float _enemylife;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fromToMoving();
        isOut();
    }

    public void fromToMoving(){
        enemyMoving?.Invoke(new Vector2(0,yDirection));
    }

    private void isOut(){
        if (this._enemylife <= 0){
            Destroy(this.gameObject);
        }
        else if (this.transform.position.y < -6.0f){
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.transform.tag == "Player"){
            this._enemylife = 0;
        }
        else if(other.transform.tag == "PlayerBullet"){
            this._enemylife-=50;
        }
    }
}
