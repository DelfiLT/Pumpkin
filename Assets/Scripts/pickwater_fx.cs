using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickwater_fx : MonoBehaviour
{
   public static AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
       
    }

    public static void playFX(){
        audioSource.Play();
        
    }
}
