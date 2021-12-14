using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimento : MonoBehaviour
{
    // Start is called before the first frame update

    private float vel = 4.5f;

    private float forca = 10f;
    private Rigidbody2D Player;

    private bool face = true;
    private Transform playerT;
    private Animator anim;

    private bool noAr = false;
    
    private bool liberaPulo = false;

    void Start()
    {
        Player = transform.GetComponent<Rigidbody2D>();
        playerT = GetComponent<Transform>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Correr();
        Pular();
    }

    void Flip()
    {
        face = !face;
        Vector3 scala = playerT.localScale;
        scala.x *= -1;
        playerT.localScale = scala;
    }

    void AnimacaoPuloLateral(){
        
        anim.SetBool("idle", false);
        anim.SetBool("pular", true);   
    }

    void AnimacaoIdle(){
            anim.SetBool("andar", false);
            anim.SetBool("idle", true);
    }
    void Correr(){        

        if (Input.GetKey(KeyCode.D))
        { 
            if(!face){
                Flip();            
            }
            anim.SetBool("idle", false);
            anim.SetBool("andar", true);        
            transform.Translate(new Vector3(vel * Time.deltaTime,0,0));
        } 
        else if(Input.GetKey(KeyCode.A))
        {   
            if(face){
                Flip();            
            }      
            anim.SetBool("idle", false);
            anim.SetBool("andar", true);                     
            transform.Translate(new Vector3(-vel * Time.deltaTime,0,0));
        } else {
            AnimacaoIdle();
        }        

    }

    void Pular(){
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(liberaPulo != false){ 
                AnimacaoPuloLateral();                          
                Player.velocity = Vector2.up * forca;                
            }
        }
    }

    
    void OnCollisionEnter2D(Collision2D outro) {
        if(outro.gameObject.CompareTag("chao"))
        {
            liberaPulo = true;
            anim.SetBool("idle", true);
            anim.SetBool("pular", false); 

        }
    }

    void OnCollisionExit2D(Collision2D outro) {
        if(outro.gameObject.CompareTag("chao"))
        {
            liberaPulo = false;            
        }
    }
    
}
