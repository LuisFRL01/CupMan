using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaMovimento : MonoBehaviour
{
    // Start is called before the first frame update

    private int dano;
    void Start() {
        dano = 2;

       Invoke("DestruirBala", 2); 
    }
    void OnCollisionEnter2D(Collision2D outro) {
        if(outro.gameObject.CompareTag("chao"))
        {
            DestruirBala();
        } 
        else if(outro.gameObject.CompareTag("inimigo"))
        {
            outro.gameObject.GetComponent<InimigosAI>().Dano(dano);                
            DestruirBala();
        }
    }

    void DestruirBala(){
        Destroy(gameObject);
    }

    
}
