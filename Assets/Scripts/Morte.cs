using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Morte : MonoBehaviour
{
    private float distancia;
    public LayerMask layerInimigo;    
    private Animator animator;

    void Start() {
        distancia = 1;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.forward, distancia, layerInimigo);

        if(hitInfo.collider != null)
        {

            if(hitInfo.collider.CompareTag("inimigo"))
            {
                
            } 
        } 
          
    }

    void OnCollisionExit2D(Collision2D outro) 
    {
        if(outro.gameObject.CompareTag("inimigo"))
        {
            animator.SetBool("morto", true);
            Invoke("DestruirPlayer", .5f);         
        }
    }

    void DestruirPlayer(){
        Destroy(gameObject);
    }  
}
