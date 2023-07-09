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

    private Audio audioSource;


    void Start()
    {
        audioSource = FindObjectOfType<Audio>();
    }

    void Update()
    {
        SpriteRenderer sRenderer = GetComponent<SpriteRenderer>();
        // if not usable, dim the plot's color 
        if (!usable)
        {
            sRenderer.color = new Color(sRenderer.color.r, sRenderer.color.g, sRenderer.color.b, .5f);
        }
        else 
        {
            sRenderer.color = new Color(sRenderer.color.r, sRenderer.color.g, sRenderer.color.b, 1);
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
        newHuman.GetComponentsInChildren<Animator>()[1].SetInteger("Skin",Random.Range(0, 5) + 1);
        Color c = GetComponentsInChildren<SpriteRenderer>()[1].color;
        GetComponentsInChildren<SpriteRenderer>()[1].color = new Color(c.r, c.g, c.b, 1);
        this.human = newHuman;
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
        human = null;
        FindObjectOfType<LevelManager>().keys -= 1;
        FindObjectOfType<LevelManager>().humansFreed += 1;
        GetComponentInChildren<Animator>().SetBool("Unlocked", true);
        StartCoroutine(LevelManager.FadeSpriteCoroutine(GetComponentsInChildren<SpriteRenderer>()[1], 0, 2));
        return true;
    }
}
