using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Galxy{
    public class PlayerAnimation : MonoBehaviour
    {
        [SerializeField]
        private Animator _anims;
        // Start is called before the first frame update
        void Start()
        {
            this._anims = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            LeftorRigth();
        }

        private void LeftorRigth(){
            if (Input.GetKeyDown(KeyCode.D)){
                _anims.SetBool("Turn_Rigth",true);
                _anims.SetBool("Turn_Left",false);
            }
            else if(Input.GetKeyUp(KeyCode.D)){
                _anims.SetBool("Turn_Rigth",false);
                _anims.SetBool("Turn_Left",false);
            } 
            
            if(Input.GetKeyDown(KeyCode.A)){
                _anims.SetBool("Turn_Left",true);
                _anims.SetBool("Turn_Rigth",false);
            }
            else if (Input.GetKeyUp(KeyCode.A)){
                _anims.SetBool("Turn_Left",false);
                _anims.SetBool("Turn_Rigth",false);
            }
        }
    }
}
