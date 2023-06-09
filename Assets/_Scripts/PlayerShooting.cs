using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Galxy{
    public class PlayerShooting : MonoBehaviour
    {
        [SerializeField]
        private GameObject _laserPrefab;
        // Start is called before the first frame update
        private float _fireRate = 0.12f;
        private float _nextFire = 0.0f;
        public UnityEvent playAudio;
        public UnityEvent play3Audio;
        // Update is called once per frame

        public void TripleShooting(){
            if(Input.GetKey(KeyCode.Space) && Time.time > _nextFire){
                Instantiate(_laserPrefab,this.transform.position + new Vector3(0, 0.88f, 0), Quaternion.identity) ;
                Instantiate(_laserPrefab,this.transform.position + new Vector3(0.47f, 0.05f, 0), Quaternion.identity) ;
                Instantiate(_laserPrefab,this.transform.position + new Vector3(-0.47f, 0.05f, 0), Quaternion.identity) ;
                _nextFire = Time.time + _fireRate;
                play3Audio?.Invoke();
            }
        }
        public void NormalShooting(){
            if(Input.GetKey(KeyCode.Space) && Time.time > _nextFire){
                Instantiate(_laserPrefab,this.transform.position + new Vector3(0, 0.88f, 0), Quaternion.identity) ;
                _nextFire = Time.time + _fireRate;
                playAudio?.Invoke();
            }
        }
    }
}