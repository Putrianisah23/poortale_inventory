using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeController : MonoBehaviour
{
    FadeInOut fade;
    // Start is called before the first frame update
    void Start()
    {
        fade = GetComponent<FadeInOut>();  //akses script fade

        fade.FadeOut(); //mulai fadeout
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

//fade = FindObjectOfType<FadeInOut>();
