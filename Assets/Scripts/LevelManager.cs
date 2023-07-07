using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    const int TIER_ONE = 0;
    const int TIER_TWO = 30;
    const int TIER_THREE = 60;
    const int TIER_FOUR = 100;

    /// <summary>
    /// The amount of gold the player has
    /// </summary>
    public int gold;

    /// <summary>
    /// The amount of humans the player has freed
    /// </summary>
    public int humansFreed;

    /// <summary>
    /// All the plots in the level
    /// </summary>
    private Plot[] plots;
    
    /// <summary>
    /// Returns the index of the next available plot, or -1 if no empty plot was found
    /// </summary>
    public int PlotAvailable 
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

    private void Awake() 
    {
        plots = GameObject.FindObjectsOfType<Plot>();
    }

    /// <summary>
    /// Adds the human to the next available plot, if there is one. Returns the int representing the plot or -1 if no plot was found
    /// </summary>
    /// <param name="human"></param>
    /// <returns></returns>
    public int AddToNextPlot(Human human){
        int index = PlotAvailable;
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
}
