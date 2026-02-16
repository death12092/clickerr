using TMPro;
using UnityEngine;

public class storeupgrtade : MonoBehaviour
{
    public TMP_Text pricetext;
    public TMP_Text incomeinfotext;
    
   public GameManager gamemanager;

    public int startprice = 10;
    public float upgradePriceMultiplyer = 1.5f;
    public float rocksPerupgrade = 0.1f;
    int levle = 0;

    private int CalculatePrice()
    {
        int price = Mathf.RoundToInt(startprice * Mathf.Pow(upgradePriceMultiplyer, levle));
        return price;
    }

    public float CalculateIncomePerSecond()
    {
        return rocksPerupgrade * levle;
    }
    private void Start()
    {
        updateui();
    }

    void updateui()
    {
        pricetext.text = CalculatePrice().ToString();
        incomeinfotext.text = levle.ToString() + "x" + rocksPerupgrade + "/s";

    }
    public void ClickAction()
    {

        int price = CalculatePrice();
        bool purchasesuccess = gamemanager.purchaseaction(price);
        if (purchasesuccess)
        {
            levle++;
            updateui();
        }

            


    }

}

