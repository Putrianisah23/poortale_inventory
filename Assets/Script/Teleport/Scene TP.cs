using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //biar bisa ganti scene(?)

public class SceneTP : MonoBehaviour
{
    FadeInOut fade;

    public string sceneName; //buat isi nama scene dari luar tapi kalo bisa diganti jadi drag drop scenenya langsung lebih bagus walaupun belum tau gimana

    void Update()
    {
        fade = GetComponent<FadeInOut>();   //buat akses script fade kayanya
    }

    public IEnumerator ChangeScene()
    {
        Debug.Log("a");
        fade.FadeIn();  //mulai fadein
        yield return new WaitForSeconds(1); //nunggu dulu
        SceneManager.LoadScene(sceneName); //tp ke scene tsb
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) //ngecek collidenya player
        {
            StartCoroutine(ChangeScene());
        }
    }
}
