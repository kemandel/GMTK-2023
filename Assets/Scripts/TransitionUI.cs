using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// turns on/off appropriate UI at night and day
/// </summary>
public class TransitionUI : MonoBehaviour
{
    public Canvas shopCanvas;
    public GameObject dayCanvas;
    public Canvas nightCanvas;

    public float transitionTime;

    public IEnumerator DayUICoroutine()
    {
        // Fade out images for nighttime
        foreach (Image i in nightCanvas.GetComponentsInChildren<Image>())
        {
            i.CrossFadeAlpha(1, 0, false);
            i.CrossFadeAlpha(0, transitionTime / 2, false);
        }
        // Fade out text for nighttime
        foreach (TMPro.TMP_Text t in nightCanvas.GetComponentsInChildren<TMPro.TMP_Text>())
        {
            t.CrossFadeAlpha(1, 0, false);
            t.CrossFadeAlpha(0, transitionTime / 2, false);
        }
        yield return new WaitForSeconds(transitionTime / 2);
        nightCanvas.gameObject.SetActive(false);

        dayCanvas.gameObject.SetActive(true);
        // Fade in images for daytime
        foreach (Image i in dayCanvas.GetComponentsInChildren<Image>())
        {
            i.CrossFadeAlpha(0, 0, false);
            i.CrossFadeAlpha(1, transitionTime / 2, false);
        }
        // Fade in text for daytime
        foreach (TMPro.TMP_Text t in dayCanvas.GetComponentsInChildren<TMPro.TMP_Text>())
        {
            t.CrossFadeAlpha(0, 0, false);
            t.CrossFadeAlpha(1, transitionTime / 2, false);
        }
    }

    public IEnumerator NightUICoroutine()
    {
        shopCanvas.gameObject.SetActive(false);
        // Fade out images for daytime
        foreach (Image i in dayCanvas.GetComponentsInChildren<Image>())
        {
            i.CrossFadeAlpha(1, 0, false);
            i.CrossFadeAlpha(0, transitionTime / 2, false);
        }
        // Fade out text for daytime
        foreach (TMPro.TMP_Text t in dayCanvas.GetComponentsInChildren<TMPro.TMP_Text>())
        {
            t.CrossFadeAlpha(1, 0, false);
            t.CrossFadeAlpha(0, transitionTime / 2, false);
        }
        yield return new WaitForSeconds(transitionTime / 2);
        dayCanvas.gameObject.SetActive(false);

        nightCanvas.gameObject.SetActive(true);
        // Fade in images for nighttime
        foreach (Image i in nightCanvas.GetComponentsInChildren<Image>())
        {
            i.CrossFadeAlpha(0, 0, false);
            i.CrossFadeAlpha(1, transitionTime / 2, false);
        }
        // Fade in text for nighttime
        foreach (TMPro.TMP_Text t in nightCanvas.GetComponentsInChildren<TMPro.TMP_Text>())
        {
            t.CrossFadeAlpha(0, 0, false);
            t.CrossFadeAlpha(1, transitionTime / 2, false);
        }
    }
}
