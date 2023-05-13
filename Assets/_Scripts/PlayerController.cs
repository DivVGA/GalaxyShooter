using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Galxy{
    public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private UnityEvent<Vector2> playerMoving;
    [SerializeField]
    private UnityEvent<int> changeLive;
    [SerializeField]
    private UnityEvent<int> resetLife;
    [SerializeField]
    private UnityEvent _playDeadA;
    [SerializeField]
    private UnityEvent<int,Vector3> _sendLife;
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
        #if UNITY_STANDALONE_WIN
            playerMoving?.Invoke(new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical")));
        #elif UNITY_ANDROID
            if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved){
                Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
                playerMoving?.Invoke(touchDeltaPosition);
            }
        #endif
        takeDamage();
        IamAlive();
    }

    private void OnEnable() {
        shieldAnimator.SetActive(false);
        doIHaveShield = false;
        _life=100;
        resetLife?.Invoke((int)_life);
    }

    private void OnDisable() {
        this.transform.position = new Vector3(0.0f,0.0f,0.0f);
        
    }

    private void IamAlive(){
        if (this._life<=0){
            Instantiate(playerDeathAnimator,this.transform.position,Quaternion.identity);
            _playDeadA?.Invoke();
            this.gameObject.SetActive(false);
            // Destroy(this.gameObject);
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
    private void OnTriggerEnter(Collider other) {
        if (other.transform.tag == "Enemy"){
            if (!this.doIHaveShield) {
                this._life-=15;
                changeLive?.Invoke(15);
            }
        }
        else if (other.transform.tag == "EnemyBullet"){
            if (!this.doIHaveShield) {
                this._life-=20;
                changeLive?.Invoke(20);
            }
        }
    }

    private void takeDamage(){
        _sendLife?.Invoke((int)_life,this.transform.position);
    }
}
}