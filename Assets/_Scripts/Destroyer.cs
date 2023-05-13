using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Galxy{
    public class Destroyer : MonoBehaviour
    {
        // Start is called before the first frame update
        [SerializeField]
        private int timeToDestruction;
        void Start()
        {
            StartCoroutine(DestroyMe());
        }

        IEnumerator DestroyMe()
        {
            yield return new WaitForSeconds(this.timeToDestruction);
            Destroy(this.gameObject);
        }

    }

}
