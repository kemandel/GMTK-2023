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
    public Image locked;
    private LevelManager levelManager;
    private Audio audioManager;
    public GameObject gameOverScreen;

    private Image humanImage;
    private TMP_Text priceText;
    // Start is called before the first frame update
    void Start()
    {
        locked.gameObject.SetActive(true);
        audioManager = FindObjectOfType<Audio>();
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
                costToUnlock = LevelManager.TIER_FOUR;
                break;
        }
        levelManager = FindObjectOfType<LevelManager>();

        //update shop icon with human info
        humanImage.sprite = human.shopSprite;
        priceText.text =  human.basePrice.ToString();

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
            interactableTier = true;
        }

        //lock UI for if you can't buy this hair yet
        if (!interactableTier)
            locked.gameObject.SetActive(true);
        else
            locked.gameObject.SetActive(false);

        if (levelManager.PlotUsable != -1)
            plotFree = true;
        else
            plotFree = false;

        //can buy
        if (levelManager.Gold < human.basePrice || !plotFree)
            gameObject.GetComponent<Button>().interactable = false;
        else if (levelManager.Gold >= human.basePrice && interactableTier && plotFree)
            gameObject.GetComponent<Button>().interactable = true;

        //font color
        if (levelManager.Gold < human.basePrice)
            priceText.color = Color.red;
        else
            priceText.color = Color.black;
    }
    //call OnClick, only works if button is interactable 
    public void BuyHuman()
    {
        audioManager.BuyItem();
        levelManager.AddToNextPlot(human); //why does this have a return index and also how does game know to put human in correct plot
        levelManager.AddGold(-human.basePrice);
    }

    public void BoughtTopHuman()
    {
        gameOverScreen.SetActive(true);
    }
}
