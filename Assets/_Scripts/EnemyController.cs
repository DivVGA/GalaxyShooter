using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private UnityEvent<Vector2> enemyMoving;
    private float xDirection = 1;
    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = new Vector3(0.0f,3.6f,0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        fromToMoving();
    }

    public void fromToMoving(){
        if (this.transform.position.x >= 8.0f){
            xDirection = -1;
        }
        else if(this.transform.position.x <= -8.0f){
            xDirection = 1;
        }

        enemyMoving?.Invoke(new Vector2(xDirection,0));
    }
}
