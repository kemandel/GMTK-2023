using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    /// <summary>
    /// All the plots in the level
    /// </summary>
    private Plot[] plots;
    
    /// <summary>
    /// Returns true if a plot is available and usable
    /// </summary>
    public bool PlotAvailable 
    {
        get 
        {
            for (int i = 0; i < plots.Length; i++)
            {
                if (plots[i].usable && plots[i].human == null) return true;
            }
            return false;
        }
    }

    private void Awake() 
    {
        plots = GameObject.FindObjectsOfType<Plot>();
    }
}
