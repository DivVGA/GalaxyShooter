using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private UnityEvent<Vector2> playerMoving;
    [SerializeField]
    private GameObject playerDeathAnimator;
    [SerializeField]
    private GameObject shieldAnimator;

    [SerializeField]
    private float _life;
    private bool doIHaveShield = false;
    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = new Vector3(0.0f,0.0f,0.0f);
        shieldAnimator.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        playerMoving?.Invoke(new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical")));
        IamAlive();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.transform.tag == "Enemy"){
            if (!this.doIHaveShield) {
                this._life-=15;
            }
        }
        else if (other.transform.tag == "EnemyBullet"){
            if (!this.doIHaveShield) {
                this._life-=20;
            }
        }
    }

    private void IamAlive(){
        if (this._life<=0){
            Instantiate(playerDeathAnimator,this.transform.position,Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

    public void activeShield(){
        this.doIHaveShield = true;
        shieldAnimator.SetActive(true);
    }
    public void desactiveShield(){
        this.doIHaveShield = false;
        shieldAnimator.SetActive(false);
    }
}
