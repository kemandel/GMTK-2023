using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour
{
    /// <summary>
    /// The sprite of the human in the shop
    /// </summary>
    public Sprite shopSprite;
    /// <summary>
    /// The sprite of the human with short hair in the overworld
    /// </summary>
    public float growthSpeed;
    /// <summary>
    /// The base price of the human
    /// </summary>
    public int basePrice;
    /// <summary>
    /// The amount of gold gained from cutting the hair
    /// </summary>
    public int goldValue;
    /// <summary>
    /// Whether or not the human can be harvested for gold
    /// </summary>
    private bool canHarvest;
    private DayNightCycle dayNightCycle;
    public GameObject harvestUI;
    GameObject hourglass;
    GameObject exclamation;

    private Audio audioManager;

    // Start is called before the first frame update
    void Start()
    {
        dayNightCycle = FindObjectOfType<DayNightCycle>();
        StartCoroutine(GrowCoroutine());
        audioManager = FindObjectOfType<Audio>();

        Debug.Log(harvestUI.GetComponentsInChildren<Animator>().Length);
        hourglass = harvestUI.GetComponentsInChildren<Animator>()[0].gameObject;
        exclamation = harvestUI.GetComponentsInChildren<Animator>()[1].gameObject;
    }

    public void Update()
    {
        //enables hourglass and exclamation objects, make sure hourglass is always higher in order
        if (canHarvest && dayNightCycle.day)
        {
            hourglass.gameObject.SetActive(false);
            exclamation.gameObject.SetActive(true);
        }
        else if (!canHarvest && canHarvest && dayNightCycle.day)
        {
            hourglass.gameObject.SetActive(true);
            exclamation.gameObject.SetActive(false);
        }
        else if (!dayNightCycle.day)
        {
            hourglass.gameObject.SetActive(false);
            exclamation.gameObject.SetActive(false);
        }
        GetComponentsInChildren<Animator>()[0].SetBool("CanHarvest", canHarvest);
    }
    /// <summary>
    /// Main Coroutine for growing the human's hair
    /// </summary>
    /// <returns></returns>
    IEnumerator GrowCoroutine()
    {
        while (true)
        {
            float timeStart = Time.time;
            float timePast = 0f;
            while (timePast < growthSpeed)
            {
                yield return null;
                timePast = Time.time - timeStart;
            }
            canHarvest = true;

            while (canHarvest)
            {
                yield return null;
            }
        }
    }

    /// <summary>
    /// Function to harvest the human's hair
    /// </summary>
    public void Harvest()
    {
        if (canHarvest && FindObjectOfType<DayNightCycle>().day){
            FindObjectOfType<LevelManager>().AddGold(goldValue);
            audioManager.HarvestHair();
            canHarvest = false;
        }
    }
}
