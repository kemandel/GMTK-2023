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
    /// Is the plot locked?
    /// </summary>
    private bool locked = false;

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
        if (Human != null) return;
        Human newHuman = GameObject.Instantiate(human, this.transform.position, Quaternion.identity);
        this.human = human;
        locked = true;
    }

    /// <summary>
    /// Frees the human in the plot. Returns true if successful
    /// </summary>
    /// <returns></returns>
    public bool FreeHuman()
    {
        if (Human == null) return false;
        Destroy(Human);
        locked = false;
        human = null;
        return true;
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
