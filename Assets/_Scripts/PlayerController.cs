using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private UnityEvent<Vector2> playerMoving;

    [SerializeField]
    private float _life;
    
    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = new Vector3(0.0f,0.0f,0.0f);
        
    }

    // Update is called once per frame
    void Update()
    {
        playerMoving?.Invoke(new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical")));
    }

    private void OnTriggerEnter(Collider other) {
        if (other.transform.tag == "Enemy"){
            this._life-=15;
        }
        else if (other.transform.tag == "EnemyBullet"){
            this._life-=20;
        }
    }

    private void IamAlive(){
        if (this._life<=0){
            Destroy(this.gameObject);
        }
    }
}
