using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInimigoVertical : MonoBehaviour
{

    private float vel;

    private Transform inimigoT;
    
    public bool face = true;

    private Rigidbody2D Inimigo;
    // Start is called before the first frame update
    void Start()
    {
        Inimigo = transform.GetComponent<Rigidbody2D>();
        inimigoT = GetComponent<Transform>();
        vel = 2f;
    }

    void Flip()
    {
        face = !face;
        Vector3 scala = inimigoT.localScale;
        scala.x *= -1;
        inimigoT.localScale = scala;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0,-vel * Time.fixedDeltaTime,0));
    }

    void OnCollisionEnter2D(Collision2D outro) {
        if(outro.gameObject.CompareTag("chao"))
        {
            vel = vel*-1;
        }
    }
}
