using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// turns on/off appropriate UI at night and day
/// </summary>
public class TransitionUI : MonoBehaviour
{
    public Canvas shopCanvas;
    public GameObject daytimeCanvas;
    public Canvas nightCanvas;

    public void DayUI()
    {
        //shopCanvas.gameObject.SetActive(true);
        daytimeCanvas.gameObject.SetActive(true);
        nightCanvas.gameObject.SetActive(false);
    }

    public void NightUI()
    {
        daytimeCanvas.gameObject.SetActive(false);
        shopCanvas.gameObject.SetActive(false);
        nightCanvas.gameObject.SetActive(true);
    }
}
