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
    private Human human;

    /// <summary>
    /// The human in the plot
    /// </summary>
    public Human Human {
        get
        {
            return human;
        }
    }

    /// <summary>
    /// Adds a human to the plot if the plot is empty
    /// </summary>
    /// <param name="human"></param>
    public void AddNewHuman(Human human)
    {
        Human newHuman = GameObject.Instantiate(human, this.transform.position, Quaternion.identity);
        this.human = human;
    }

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
