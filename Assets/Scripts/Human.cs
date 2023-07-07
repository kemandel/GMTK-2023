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
    public int harvest;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = spriteShort;
    }
}
