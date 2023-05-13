using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    [SerializeField]
    private AudioClip _laser;

    [SerializeField]
    private AudioClip _3laser;

    [SerializeField]
    private AudioClip _dead;

    [SerializeField]
    private AudioClip _takeDamage;

    private void Start() {
    }
    // Update is called once per frame
    public void playLaser(){
        AudioSource.PlayClipAtPoint(_laser,Camera.main.transform.position,0.2f);
    }
    public void play3Laser(){
        AudioSource.PlayClipAtPoint(_3laser,Camera.main.transform.position,0.2f);
    }

    public void playDead(){
        AudioSource.PlayClipAtPoint(_dead,Camera.main.transform.position,0.4f);
    }
    public void playTakeDamage(){
        AudioSource.PlayClipAtPoint(_takeDamage,Camera.main.transform.position,0.4f);
    }
}
