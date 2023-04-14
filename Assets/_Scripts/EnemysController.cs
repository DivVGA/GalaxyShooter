using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemysController : MonoBehaviour
{

    [SerializeField]
    private GameObject _basicEnemy;
    private List<GameObject> _enemysList = new List<GameObject>();
    private float _enemysRate = 0.5f;
    private float _nextEnemy = 2.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        _enemysList.Add(_basicEnemy);
    }

    // Update is called once per frame
    void Update()
    {
        enemyInstantiate();
    }

    private void enemyInstantiate(){
        int numPowersUps = _enemysList.Count;
        if (Time.time > _nextEnemy){
            _nextEnemy = Time.time + Random.Range(1.0f,_enemysRate);
            float _xPos = Random.Range(-8.25f,8.25f);
            int numPowerUps = _enemysList.Count;
            Instantiate(_enemysList[(int)Random.Range(0,numPowersUps)],new Vector3(_xPos, 6.0f, 0), Quaternion.identity) ;
        }
    }
}
