using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour
{
    [SerializeField]
    private GameObject _damage;
    private Vector3 _damagePos1;
    private Vector3 _damagePos2;
    private GameObject Damage1;
    private GameObject Damage2;
    private bool d1 = false;
    private bool d2 = false;
    private List<Vector3> _damagePos = new List<Vector3>();
    // Start is called before the first frame update
    void Start()
    {
        this._damagePos1=new Vector3(-0.16f,Random.Range(-0.84f,-0.06f),0.0f);
        this._damagePos2=new Vector3(0.16f,Random.Range(-0.84f,-0.06f),0.0f);
        _damagePos.Add(_damagePos1);
        _damagePos.Add(_damagePos2);
    }

    // Update is called once per frame
    private void renderDamage1(Vector3 playerPosition){
        int position = (int)Random.Range(0,_damagePos.Count-1);
        Damage1 = Instantiate(_damage,playerPosition + _damagePos[position], Quaternion.identity, this.transform.parent) ;
        _damagePos.RemoveAt(position);
    }

    private void renderDamage2(Vector3 playerPosition){
        int position = (int)Random.Range(0,_damagePos.Count-1);
        Damage2 = Instantiate(_damage,playerPosition + _damagePos[position], Quaternion.identity, this.transform.parent) ;
        _damagePos.RemoveAt(position);
    }

    public void renderDamage(int life,Vector3 pp){
        if((life <= 50 && life >= 40) && this.d1==false){
            renderDamage1(pp);
            d1 = true;
        }
        else if(life < 40 && this.d2 == false){
            renderDamage2(pp);
            d2 = true;
        }
    }

    public void NoDamage() {
        Destroy(Damage2);
        Destroy(Damage1);
        d1 = false;
        d2 = false;
        this._damagePos1=new Vector3(-0.16f,Random.Range(-0.84f,-0.06f),0.0f);
        this._damagePos2=new Vector3(0.16f,Random.Range(-0.84f,-0.06f),0.0f);
        _damagePos.Add(_damagePos1);
        _damagePos.Add(_damagePos2);
    }
}
