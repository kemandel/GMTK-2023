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
    [HideInInspector]
    public bool day;

    private int nightDayTracker = 1;
    public TMP_Text clockText;

    private TransitionUI transitionUI;
    private SheepPlayerController player;
    private Audio audioSource;
    private Coroutine runningCoroutine;
    // Start is called before the first frame update
    void Start()
    {
        transitionUI = FindObjectOfType<TransitionUI>();
        player = FindObjectOfType<SheepPlayerController>();
        audioSource = FindObjectOfType<Audio>();
        hour = startingHourDay;
        day = true;
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
        day = true;

        if (runningCoroutine != null)
        {
            StopCoroutine(runningCoroutine);
            Debug.Log("stopped Coroutine");
        }
        StartCoroutine(player.DayCoroutine());
        StartCoroutine(transitionUI.DayUICoroutine());
        audioSource.DayAudio();
    }

    void StartNight()
    {
        day = false;
        runningCoroutine = StartCoroutine(audioSource.NightAudio());
        StartCoroutine(transitionUI.NightUICoroutine());
        StartCoroutine(audioSource.NightAudio());
    }
}
