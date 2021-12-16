using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiro : MonoBehaviour
{
    public Transform Arma;
    public GameObject balaPrefab;
    public float velocidade;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Z)){
            Atirar();
        }
        
    }

    void Atirar(){

        GameObject bala = Instantiate(balaPrefab, Arma.position, transform.rotation);
  

    }
}
