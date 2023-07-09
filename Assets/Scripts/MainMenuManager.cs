using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public Image fadeOutImage;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        StartCoroutine(FadeOut());
    }

    private IEnumerator FadeOut()
    {
        fadeOutImage.GetComponent<Animator>().SetTrigger("fade");
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("MainLevel");
    }

    public void ReturnHome()
    {
        SceneManager.LoadScene("MainLevel");
    }
}
