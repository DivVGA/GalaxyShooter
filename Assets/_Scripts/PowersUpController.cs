using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowersUpController : MonoBehaviour
{
    [SerializeField]
    private GameObject _tripleShot;
    [SerializeField]
    private GameObject _moreSpeed;
    [SerializeField]
    private GameObject _shield;
    private List<GameObject> _powerUpsList = new List<GameObject>();
    private float _powerUpRate = 15.0f;
    private int _numPowerUps;

    // Start is called before the first frame update
    void Start()
    {
        _powerUpsList.Add(_tripleShot);
        _powerUpsList.Add(_moreSpeed);
        _powerUpsList.Add(_shield);
        this._numPowerUps = _powerUpsList.Count;
        StartCoroutine(SpawnPoweUP());
    }

    IEnumerator SpawnPoweUP()
    {
        while(true){
            float _xPos = Random.Range(-8.25f,8.25f);
            Instantiate(_powerUpsList[(int)Random.Range(0,_numPowerUps)],new Vector3(_xPos, 5.60f, 0), Quaternion.identity) ;
            yield return new WaitForSeconds(Random.Range(1.0f,_powerUpRate));
        }
    }
}
