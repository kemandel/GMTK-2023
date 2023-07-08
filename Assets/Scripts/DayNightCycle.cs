using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Start is called before the first frame update
    void Start()
    {
        hour = startingHourDay;
        StartDay();
        StartCoroutine(TimeCoroutine());
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
            hour %= 24;

            Debug.Log("Current Hour: " + hour);

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
    }

    void StartNight()
    {
        Debug.Log("It's Night Time!");
        FindObjectOfType<SheepPlayerController>().canMove = true;
    }
}
