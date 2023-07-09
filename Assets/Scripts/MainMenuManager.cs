using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public Image fadeOutImage;

    void Start()
    {
        FindObjectOfType<Human>().GetComponentsInChildren<Animator>()[1].SetInteger("Skin", 3);
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
