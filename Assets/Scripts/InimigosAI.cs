using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigosAI : MonoBehaviour
{

    private Animator animator;

    private int energia;

    // Start is called before the first frame update
    void Start()
    {
        energia = 8;
    }

    // Update is called once per frame
    void Update()
    {
        if(energia <= 0)
        {
            Invoke("DestroyBody", .5f);
        }
    }

    public void Dano(int dano)
    {
        energia -= dano;
    }

    private void DestroyBody()
    {
        Destroy(gameObject);
    }
}
