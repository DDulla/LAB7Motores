using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Image fadeImage; 
    public float fadeDuration = 1.0f;

    void Start()
    {
        if (fadeImage != null)
        {
            fadeImage.gameObject.SetActive(true);
            StartCoroutine(Fade());
        }
    }

    public void PLAY()
    {
        if (fadeImage == null)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    public void GoBack()
    {
        if (fadeImage == null)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }

    public void QUIT()
    {
        Debug.Log("Salir");
        Application.Quit();
    }

    IEnumerator Fade()
    {
        float elapsedTime = 0f;
        Color color = fadeImage.color;
        color.a = 1f;
        fadeImage.color = color;
        while (elapsedTime < fadeDuration)
        {
            color.a = 1f - (elapsedTime / fadeDuration);
            fadeImage.color = color;
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        color.a = 0f;
        fadeImage.color = color;
        Destroy(fadeImage.gameObject);
    }
}
