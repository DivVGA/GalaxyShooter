using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject laserPrefab;
    // Start is called before the first frame update
    private float _fireRate = 0.12f;
    private float _nextFire = 0.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Disparo
        Shooting();
    }

    private void Shooting(){
        if(Input.GetKey(KeyCode.Space) && Time.time > _nextFire){
            Instantiate(laserPrefab,this.transform.position + new Vector3(0, 0.88f, 0), Quaternion.identity) ;
            _nextFire = Time.time + _fireRate;
        }
    }
}
