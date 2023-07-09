using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlotItemShop : MonoBehaviour
{
    private int[] plotPrices = new int[] { 10, 20, 30, 40 };
    private TMP_Text plotCost;

    private int plotIndex = 0;

    private Audio audioManager;
    private LevelManager levelManager;
    // Start is called before the first frame update
    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        plotCost = GetComponentInChildren<TMP_Text>();
        audioManager = FindObjectOfType<Audio>();
    }

    // Update is called once per frame
    void Update()
    {
        plotCost.text = plotPrices[plotIndex].ToString();

        if (levelManager.Gold < plotPrices[plotIndex])
        {
            gameObject.GetComponent<Button>().interactable = false;
            plotCost.color = Color.red;
        }
        else
        {
            gameObject.GetComponent<Button>().interactable = true;
            plotCost.color = Color.black;
        }

    }

    public void BuyPlot()
    {
        if (plotIndex >= plotPrices.Length)
            return;
        audioManager.BuyItem();
        levelManager.AddGold(-plotPrices[plotIndex]);
        plotIndex++;
        int plotAvailable = levelManager.PlotPurchaseable;
        if (plotAvailable != -1)
            levelManager.GetPlot(plotAvailable).usable = true;
    }
}
