using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public TMP_Text goldText;
    public TMP_Text peopleFreedText;
    public const int TIER_ONE = 0;
    public const int TIER_TWO = 10;
    public const int TIER_THREE = 35;
    public const int TIER_FOUR = 70;

    public int startingGold;

    public int keys = 0;

    /// <summary>
    /// The amount of gold the player has, accessable to other classes
    /// </summary>
    public int Gold 
    {
        get 
        {
            return gold;
        }
    }

    /// <summary>
    /// The amount of gold the player has, private
    /// </summary>
    private int gold;

    /// <summary>
    /// The amount of humans the player has freed
    /// </summary>
    [HideInInspector]
    public int humansFreed;

    /// <summary>
    /// All the plots in the level
    /// </summary>
    private Plot[] plots;

    private void Awake() 
    {
        plots = GameObject.FindObjectsOfType<Plot>();
    }

    private void Start()
    {
        gold = startingGold;
    }

    private void Update()
    {
        //displays how many humans to free before next tier unlocked 
        if (humansFreed >= TIER_ONE)
            peopleFreedText.text = "TOTAL HUMANS FREED: " + humansFreed.ToString() + "/" + TIER_TWO;
        if (humansFreed > TIER_TWO)
            peopleFreedText.text = "TOTAL HUMANS FREED: " + humansFreed.ToString() + "/" + TIER_THREE;
        if (humansFreed > TIER_THREE)
            peopleFreedText.text = "TOTAL HUMANS FREED: " + humansFreed.ToString() + "/" + TIER_FOUR;
        goldText.text = Gold.ToString();
        // peopleFreedText.text = "TOTAL HUMANS FREED: " + humansFreed.ToString() + "/" + ;

        // Checks if the player clicked
        if (Input.GetMouseButtonDown(0))
        {
            // What to do if a collider is hit where the mouse is
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.forward, 10);
            if (hit.collider != null && hit.collider.CompareTag("Human"))
                hit.collider.GetComponent<Human>().Harvest();
        }
    }

    /// <summary>
    /// Returns the index of the next available plot, or -1 if no empty plot was found
    /// </summary>
    public int PlotUsable 
    {
        get 
        {
            for (int i = 0; i < plots.Length; i++)
            {
                if (plots[i].usable && plots[i].Human == null) return i;
            }
            return -1;
        }
    }

    /// <summary>
    /// Returns the index of the next purchaseable plot, or -1 if no plot was found
    /// </summary>
    public int PlotPurchaseable
    {
        get 
        {
            for (int i = 0; i < plots.Length; i++)
            {
                if (!plots[i].usable && plots[i].Human == null) return i;
            }
            return -1;
        }
    }

    /// <summary>
    /// Adds the human to the next available plot, if there is one. Returns the int representing the plot or -1 if no plot was found
    /// </summary>
    /// <param name="human"></param>
    /// <returns></returns>
    public int AddToNextPlot(Human human){
        int index = PlotUsable;
        if (index > -1){
            plots[index].AddNewHuman(human);
        }
        return index;
    }

    /// <summary>
    /// Returns the plot found at the specified index or null if no plot was found
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public Plot GetPlot(int index){
        try
        {
            return plots[index];
        }
        catch 
        {
            return null;
        }
    }

    /// <summary>
    /// Add gold to the player's gold amount
    /// </summary>
    /// <param name="value"></param>
    public void AddGold(int value){
        gold += value;
    }
}
