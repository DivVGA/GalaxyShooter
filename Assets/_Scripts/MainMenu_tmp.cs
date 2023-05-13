using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Galxy{
public class MainMenu_tmp : MonoBehaviour
    {
        public GameObject player;
        public GameObject puController;
        public GameObject eController;
        public GameObject score;
        public GameObject life;
        public GameObject shield;
        public UIManagger Canvas;
        public Image imagen;
        // Start is called before the first frame update
        void Start()
        {
            this.player.SetActive(false);
            this.puController.SetActive(false);
            this.eController.SetActive(false);
            this.score.SetActive(false);
            this.life.SetActive(false);
            this.shield.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {
            if (player.gameObject.activeSelf == false)
            {
                this.puController.SetActive(false);
                this.eController.SetActive(false);
                this.Canvas.resetScore();
                this.imagen.enabled=true;
            }

            if(Input.GetKey(KeyCode.Escape)){
                this.player.SetActive(true);
                this.player.SetActive(true);
                this.puController.SetActive(true);
                this.eController.SetActive(true);
                this.score.SetActive(true);
                this.life.SetActive(true);
                this.shield.SetActive(true);
                this.imagen.enabled=false;
            }

        }
    }

}
