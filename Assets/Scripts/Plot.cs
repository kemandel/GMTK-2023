using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plot : MonoBehaviour
{
    /// <summary>
    /// Is the plot usable by the player?
    /// </summary>
    public bool usable = false;

    /// <summary>
    /// The human in the plot
    /// </summary>
    public Human human = null;

    void Start()
    {
        // if not usable, dim the plot's color 
        if (!usable)
        {
            SpriteRenderer sRenderer = GetComponent<SpriteRenderer>();
            sRenderer.color = new Color(sRenderer.color.r, sRenderer.color.g, sRenderer.color.b, .5f);
        }
    }
}
