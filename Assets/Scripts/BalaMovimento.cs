using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaMovimento : MonoBehaviour
{
    // Start is called before the first frame update

    void Start() {
       Invoke("DestruirBala", 2); 
    }

    void DestruirBala(){
        Destroy(gameObject);
    }
}
