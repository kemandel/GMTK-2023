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
    private int costToUnlock;
    public bool interactableTier = true;
    public bool plotFree;
    private LevelManager levelManager;

    private Image humanImage;
    private TMP_Text priceText;
    // Start is called before the first frame update
    void Start()
    {

        humanImage = GetComponentsInChildren<Image>()[1];
        priceText = GetComponentInChildren<TMP_Text>();
        switch (tier)
        {
            case 1:
                costToUnlock = LevelManager.TIER_ONE;
                break;
            case 2:
                costToUnlock = LevelManager.TIER_TWO;
                break;
            case 3:
                costToUnlock = LevelManager.TIER_THREE;
                break;
            case 4:
                costToUnlock = LevelManager.TIER_THREE;
                break;
        }
        levelManager = FindObjectOfType<LevelManager>();

        //update shop icon with human info
        humanImage.sprite = human.shopSprite;
        priceText.text = "$" + human.basePrice;

        if (costToUnlock > levelManager.humansFreed) //haven't unlocked this option yet
        {
            this.gameObject.GetComponent<Button>().interactable = false;
            interactableTier = false;
        }
    }

    private void Update()
    {

        //unlock this tier
        if (!interactableTier && costToUnlock <= levelManager.humansFreed) 
        {
            //this.gameObject.GetComponent<Button>().interactable = true;
            interactableTier = true;
        }

        if (levelManager.PlotAvailable != -1)
            plotFree = true;
        else
            plotFree = false;

        //can buy
        if (levelManager.gold < human.basePrice || !plotFree)
            gameObject.GetComponent<Button>().interactable = false;
        else if (levelManager.gold > human.basePrice && interactableTier && plotFree)
            gameObject.GetComponent<Button>().interactable = true;
    }
    //call OnClick, only works if button is interactable 
    public void BuyHuman()
    {
        levelManager.AddToNextPlot(human); //why does this have a return index and also how does game know to put human in correct plot
    }
}