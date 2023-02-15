using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fx_menu_click : MonoBehaviour
{
    public static  AudioSource menuClick;
    // Start is called before the first frame update
    void Start()
    {
        menuClick = GetComponent<AudioSource>();
    }

    public static  void playSound(){
        menuClick.Play();
    }
}
