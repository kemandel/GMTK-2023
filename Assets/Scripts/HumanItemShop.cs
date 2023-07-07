using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
/// <summary>
/// attach to human item in shop
/// </summary>
public class HumanItemShop : MonoBehaviour
{
    public Human human;
    public int tier;
    public bool interactableTier = true;
    private LevelManager bank;

    public Image humanImage;
    public TMP_Text priceText;
    // Start is called before the first frame update
    void Start()
    {
        bank = FindObjectOfType<LevelManager>();

        //update shop icon with human info
        humanImage.sprite = human.shopSprite;
        priceText.text = "$" + human.basePrice;

        if (tier == 2) //&& humansFreed <  # needed to free per tier  
        {
            this.gameObject.GetComponent<Button>().interactable = false;
            interactableTier = false;
        }
    }

    private void Update()
    {
        //can buy
        if (bank.gold < human.basePrice)
            gameObject.GetComponent<Button>().interactable = false;
        else if (bank.gold > human.basePrice && interactableTier)
            gameObject.GetComponent<Button>().interactable = true;

        if (!interactableTier) //&& humansFreed >=  # needed to free per tier  
        {
            this.gameObject.GetComponent<Button>().interactable = true;
            interactableTier = true;
        }

    }
    //call OnClick 
    public void BuyHuman()
    {
        //if plot free
        //

    }
}
