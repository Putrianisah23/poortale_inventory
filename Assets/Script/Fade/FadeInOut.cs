using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInOut : MonoBehaviour
{

    public CanvasGroup canvasgroup;
    public bool fadein = false;
    public bool fadeout = false;

    public float TimeToFade;
    
    // Update is called once per frame
    void Update()
    {
        if(fadein == true)
        {
            if(canvasgroup.alpha < 1)  //ngecek transparansi gambar (transparan)
            {
                canvasgroup.alpha += TimeToFade * Time.deltaTime; //maka fade in akan dilakukan
                if(canvasgroup.alpha >= 1)  //ngecek transparansi gambar (opaque)
                {
                    fadein = false;  //fadein dibikin false kembali
                }
            }
        }
        if (fadeout == true)
        {
            if (canvasgroup.alpha >= 0)  //ngecek transparansi gambar (opaque)
            {
                canvasgroup.alpha -= TimeToFade * Time.deltaTime; //maka fade out akan dilakukan
                if (canvasgroup.alpha == 0)  //ngecek transparansi gambar (transparan)
                {
                    fadeout = false;  //fadeout dibikin false kembali
                }
            }
        }
    }

    public void FadeIn()
    {
        fadein = true;
    }

    public void FadeOut()
    {
        fadeout = true;
    }

}
