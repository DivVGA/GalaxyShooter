using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowersUpController : MonoBehaviour
{
    [SerializeField]
    private GameObject _tripleShot;
    [SerializeField]
    private GameObject _moreSpeed;
    private List<GameObject> _powerUpsList = new List<GameObject>();
    private float _powerUpRate = 7.0f;

    private float _nextPowerUp = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        _powerUpsList.Add(_tripleShot);
        _powerUpsList.Add(_moreSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        int numPowersUps = _powerUpsList.Count;
        if (Time.time > _nextPowerUp){
            _nextPowerUp = Time.time + Random.Range(1.0f,_powerUpRate);
            float _xPos = Random.Range(-8.25f,8.25f);
            int numPowerUps = _powerUpsList.Count;
            Instantiate(_powerUpsList[(int)Random.Range(0,numPowersUps)],new Vector3(_xPos, 5.60f, 0), Quaternion.identity) ;
        }
    }
}
