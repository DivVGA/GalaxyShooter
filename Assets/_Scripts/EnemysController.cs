using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemysController : MonoBehaviour
{

    [SerializeField]
    private GameObject _basicEnemy;
    private List<GameObject> _enemysList = new List<GameObject>();
    private float _enemysRate = 0.5f;
    private int _numEnemysUps;
    
    // Start is called before the first frame update
    void Start()
    {
        _enemysList.Add(_basicEnemy);
        this._numEnemysUps = _enemysList.Count;
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while(true){
            float _xPos = Random.Range(-8.25f,8.25f);
            Instantiate(_enemysList[(int)Random.Range(0,_numEnemysUps)],new Vector3(_xPos, 6.0f, 0), Quaternion.identity) ;
            yield return new WaitForSeconds(Random.Range(1.0f,_enemysRate));
        }
    }
}
