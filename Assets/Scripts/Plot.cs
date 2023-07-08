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

    private Audio audioSource;


    void Start()
    {
        audioSource = FindObjectOfType<Audio>();
        // if not usable, dim the plot's color 
        if (!usable)
        {
            SpriteRenderer sRenderer = GetComponent<SpriteRenderer>();
            sRenderer.color = new Color(sRenderer.color.r, sRenderer.color.g, sRenderer.color.b, .5f);
        }
    }
    /// <summary>
    /// Adds a human to the plot if the plot is empty
    /// </summary>
    /// <param name="human"></param>
    public void AddNewHuman(Human human)
    {
        if (Human != null) return;
        Human newHuman = GameObject.Instantiate(human, this.transform.position + Vector3.up * .5f, Quaternion.identity);
        Sprite[] possibleSkins = Resources.LoadAll<Sprite>("Skin/");
        newHuman.GetComponentsInChildren<SpriteRenderer>()[1].sprite = possibleSkins[Random.Range(0, possibleSkins.Length)];
        this.human = newHuman;
        locked = true;
    }

    /// <summary>
    /// Frees the human in the plot. Returns true if successful
    /// </summary>
    /// <returns></returns>
    public bool FreeHuman()
    {
        if (Human == null) return false;
        if (FindObjectOfType<LevelManager>().keys <= 0) return false;
        Destroy(human.gameObject);
        audioSource.FreeHuman();
        locked = false;
        human = null;
        FindObjectOfType<LevelManager>().keys -= 1;
        FindObjectOfType<LevelManager>().humansFreed += 1;
        return true;
    }
}
