using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    public AudioClip tiroPlayer;
    public AudioSource audioSource;

    private Animator anim;

    public AudioClip morte;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            audioSource.clip = tiroPlayer;
            audioSource.Play();
        } 
        if (anim.GetBool("morto"))
        {
            audioSource.clip = morte;
            audioSource.Play();
        }
    }
}
