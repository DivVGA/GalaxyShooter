using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private float force;
    private Rigidbody _rigibody;
    // Start is called before the first frame update
    void Start()
    {
        _rigibody = this.transform.GetComponent<Rigidbody>();
        _rigibody.AddForce(Vector3.up*force);
    }

    // Update is called once per frame
    void FixedUpdate() {
        Destroyer();
    }

    private void Destroyer(){
        if (this.transform.position.y > 5.5f){
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.transform.tag == "Enemy"){
            Destroy(this.gameObject);
        }
    }
}
