using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Galxy{
    public class PowerUp : MonoBehaviour
    {
        [SerializeField]
        private float force;
        [SerializeField]
        private int type;
        private Rigidbody _rigibody;
        [SerializeField]
        private AudioClip _powerUPClip;
        // Start is called before the first frame update

        void Start()
        {
            _rigibody = this.transform.GetComponent<Rigidbody>();
            _rigibody.AddForce(Vector3.down*force);
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if (this.transform.position.y < -5.6f){
                Destroyer();
            }
        }

        public void Destroyer(){
            Destroy(this.gameObject);
        }

        private void OnTriggerEnter(Collider other) {
            if (other.tag=="Player"){
                AudioSource.PlayClipAtPoint(_powerUPClip,Camera.main.transform.position,0.8f);
                Destroyer();
            }
        }

        public new int GetType(){
            return this.type;
        }
    }
}
