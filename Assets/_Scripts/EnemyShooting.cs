using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField]
    private EnemyLaser _laserPrefab;
    // Start is called before the first frame update
    private float _fireRate = 3.0f;
    private float _nextFire = 0.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TripleShooting();
    }

    public void TripleShooting(){
        if(Time.time > _nextFire){
            EnemyLaser tmp1 = Instantiate(_laserPrefab,this.transform.position + new Vector3(0, -0.7f, 0), Quaternion.identity) ;
            tmp1.frontLaser();
            EnemyLaser tmp2 = Instantiate(_laserPrefab,this.transform.position + new Vector3(0, -0.7f, 0), Quaternion.Euler(0,0,-45)) ;
            tmp2.leftLaser();
            EnemyLaser tmp3 = Instantiate(_laserPrefab,this.transform.position + new Vector3(0, -0.7f, 0), Quaternion.Euler(0,0,45)) ;
            tmp3.rightLaser();
            _nextFire = Time.time + _fireRate;
        }
    }
}
