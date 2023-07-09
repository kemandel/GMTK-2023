using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KeyItemShop : MonoBehaviour
{
    private int[] keyPrices = new int[] { 1, 3, 5, 7, 9 };
    private TMP_Text keyCostText;

    private int keyIndex = 0;
    public TMP_Text keysOwnedDayText;
    public TMP_Text keysOwnedNightText;

    private Audio audioManager;
    private LevelManager levelManager;
    // Start is called before the first frame update
    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        keyCostText = GetComponentInChildren<TMP_Text>();
        audioManager = FindObjectOfType<Audio>();
    }

    // Update is called once per frame
    void Update()
    {
        keysOwnedDayText.text = levelManager.keys.ToString();
        keysOwnedNightText.text = levelManager.keys.ToString();
        keyCostText.text = keyPrices[keyIndex].ToString();

        if (levelManager.Gold < keyPrices[keyIndex])
        {
            gameObject.GetComponent<Button>().interactable = false;
            keyCostText.color = Color.red;
        }
        else
        {
            gameObject.GetComponent<Button>().interactable = true;
            keyCostText.color = Color.black;
        }
           
    }
    
    public void BuyKey()
    {
        if (keyIndex >= keyPrices.Length)
            return;
        audioManager.BuyItem();
        levelManager.AddGold(-keyPrices[keyIndex]);
        keyIndex++;
        levelManager.keys++;
    }
}
