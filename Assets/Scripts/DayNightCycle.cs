using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DayNightCycle : MonoBehaviour
{
    /// <summary>
    /// How many seconds it takes for an hour to pass
    /// </summary>
    public float secondsPerHour;
    /// <summary>
    /// The hour the day starts at
    /// </summary>
    public int startingHourDay;
    /// <summary>
    /// The hour the day ends at
    /// </summary>
    public int endingHourDay;
    /// <summary>
    /// The current hour
    /// </summary>
    [HideInInspector]
    public int hour;

    private int nightDayTracker = 1;
    public TMP_Text clockText;

    private TransitionUI transitionUI;
    // Start is called before the first frame update
    void Start()
    {
        transitionUI = FindObjectOfType<TransitionUI>();
        hour = startingHourDay;
        StartCoroutine(TimeCoroutine());
    }

    private void Update()
    {
        if (hour + 1 == 12)
            clockText.text = hour + 1 + ":00 PM";
        else if (hour + 1 == 24)
            clockText.text = hour + 1 - 12 + ":00 AM";
        else if (hour + 1 > 12)
            clockText.text = hour + 1 - 12 + ":00 PM";
        else
            clockText.text = hour + 1 + ":00 AM";
    }

    /// <summary>
    /// Coroutine to increment time over the course of the game
    /// </summary>
    /// <returns></returns>
    private IEnumerator TimeCoroutine()
    {
        while (true)
        {
            float timeStart = Time.time;
            float timePast = 0f;

            while (timePast < secondsPerHour)
            {
                yield return null;
                timePast = Time.time - timeStart;
            }

            hour++;
            nightDayTracker++;
            hour %= 24;

            if (hour == startingHourDay)
            {
                StartDay();
            }

            if (hour == endingHourDay)
            {
                StartNight();
            }
        }
    }

    void StartDay()
    {
        Debug.Log("It's Day Time!");
        FindObjectOfType<SheepPlayerController>().canMove = false;
        StartCoroutine(transitionUI.DayUICoroutine());
    }

    void StartNight()
    {
        Debug.Log("It's Night Time!");
        FindObjectOfType<SheepPlayerController>().canMove = true;
        StartCoroutine(transitionUI.NightUICoroutine());
    }
}
