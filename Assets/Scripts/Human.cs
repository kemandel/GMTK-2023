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
    public Sprite spriteShort;
    /// <summary>
    /// The sprite of the human with long hair in the overworld
    /// </summary>
    public Sprite spriteLong;
    /// <summary>
    /// How fast the hair grows in seconds
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

    // Start is called before the first frame update
    void Start()
    {
        GetComponentInChildren<SpriteRenderer>().sprite = spriteShort;
        StartCoroutine(GrowCoroutine());
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

            GetComponentInChildren<SpriteRenderer>().sprite = spriteLong;
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
        if (canHarvest){
            FindObjectOfType<LevelManager>().AddGold(goldValue);
            GetComponentInChildren<SpriteRenderer>().sprite = spriteShort;
            canHarvest = false;
        }
    }
}
