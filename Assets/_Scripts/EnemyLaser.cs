using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaser : MonoBehaviour
{
    [SerializeField]
    private float force;
    private Rigidbody _rigibody;
    // Start is called before the first frame update
    void Start()
    {
        // //Bala delantera
        // _rigibodyFront = _rigibodyFront.transform.GetComponent<Rigidbody>();
        // _rigibodyFront.AddForce(-1*Vector3.up*force);

        // //Bala izquierda
        // _rigibodyLeft =  _rigibodyLeft.transform.GetComponent<Rigidbody>();
        // _rigibodyLeft.AddForce((-1*Vector3.up+Vector3.left)*force);

        // //Bala derecha
        // _rigibodyRight = _rigibodyRight.transform.GetComponent<Rigidbody>();
        // _rigibodyRight.AddForce((-1*Vector3.up+Vector3.right)*force);
    }

    // Update is called once per frame
    void FixedUpdate() {
        Destroyer();
    }

    private void Destroyer(){
        if (this.transform.position.y < -6.0f){
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.transform.tag == "Player"){
            Destroy(this.gameObject);
        }
    }
    public void frontLaser(){
        _rigibody = this.transform.GetComponent<Rigidbody>();
        _rigibody.AddForce(-1*Vector3.up*force);
    }
    public void leftLaser(){
        _rigibody = this.transform.GetComponent<Rigidbody>();
        _rigibody.AddForce((-1*Vector3.up+Vector3.left)*force);
    }
    public void rightLaser(){
        _rigibody = this.transform.GetComponent<Rigidbody>();
        _rigibody.AddForce((-1*Vector3.up+Vector3.right)*force);
    }
}
