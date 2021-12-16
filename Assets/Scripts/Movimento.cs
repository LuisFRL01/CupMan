using UnityEngine;

public class Movimento : MonoBehaviour
{
    // Start is called before the first frame update

    private float vel = 6f;

    private float forca = 10f;
    private Rigidbody2D Player;

    public bool face = true;
    private Transform playerT;
    private Animator anim;

    private bool liberaPulo = false;

    public Transform Arma;
    public GameObject balaPrefab;

    public GameController gameController;

    private float velocidadeBala;
    private float tempoDisparo;
    private float proximoTiro;

    void Start()
    {
        Player = transform.GetComponent<Rigidbody2D>();
        playerT = GetComponent<Transform>();
        anim = GetComponent<Animator>();
        velocidadeBala = 10f;
        tempoDisparo = 0.2f;
    }

    void FixedUpdate()
    {        
        Movimentacao();        
    }

    void Update() 
    {
        Pulo();
        AnimacaoTiro();
        Atirar();
    }

    void Flip()
    {
        face = !face;
        Vector3 scala = playerT.localScale;
        scala.x *= -1;
        playerT.localScale = scala;
    }

    void AnimacaoPuloLateral()
    {
        anim.SetBool("idle", false);
        anim.SetBool("pular", true);
    }

    void AnimacaoTiro()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            anim.SetBool("atirar", true);
        } else {
            anim.SetBool("atirar", false);
        }
    }

    void AnimacaoIdle()
    {
        anim.SetBool("andar", false);
        anim.SetBool("idle", true);
        anim.SetBool("atirar", false);
    }
    void Pulo()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (liberaPulo != false)
            {
                AnimacaoPuloLateral();
                Player.velocity = Vector2.up * forca;
            }
        }
    }

    void Movimentacao()
    {        
        if (Input.GetKey(KeyCode.D))
        { 
            if(!face){
                Flip();            
            }
            anim.SetBool("idle", false);
            anim.SetBool("andar", true);        
            transform.Translate(new Vector3(vel * Time.fixedDeltaTime,0,0));
        } 
        else if(Input.GetKey(KeyCode.A))
        {   
            if(face){
                Flip();            
            }      
            anim.SetBool("idle", false);
            anim.SetBool("andar", true);                     
            transform.Translate(new Vector3(-vel * Time.fixedDeltaTime,0,0));
        } 
        else {
            AnimacaoIdle();
        }        

    }

    void Atirar()
    {       
        if(Input.GetKey(KeyCode.Z) && Time.time > proximoTiro){
            gameController.playAudioTiro();
            proximoTiro = Time.time + tempoDisparo;
            GameObject bala = Instantiate(balaPrefab, Arma.position, transform.rotation);  
            if(face){
                bala.GetComponent<Rigidbody2D>().velocity = new Vector2(velocidadeBala, 0);
            } else {
                bala.GetComponent<Rigidbody2D>().velocity = new Vector2(-velocidadeBala, 0);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D outro)
    {
        if (outro.gameObject.CompareTag("chao"))
        {
            liberaPulo = true;
            anim.SetBool("idle", true);
            anim.SetBool("pular", false);
        }

        if (outro.gameObject.CompareTag("morte"))
        {
            Player.velocity = Vector2.zero;
        }
    }

    void OnCollisionExit2D(Collision2D outro) 
    {
        if(outro.gameObject.CompareTag("chao"))
        {
            liberaPulo = false;
        }
    }
}