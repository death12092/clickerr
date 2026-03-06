using TMPro;
using UnityEngine;

public class employeeupgrade : MonoBehaviour
{
    public TMP_Text pricetext;
    public TMP_Text incomeinfotext;

    public GameManager gamemanager;

    public int startprice = 5;
    public float upgradePriceMultiplyer = 1.25f;
    public float rocksPerupgrade = 1.0f;
    public int levle = 0;
    public bool active;

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
    public void Update()
    {

    }

    void updateui()
    {
        Debug.Log("Updating");
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
    public void activate()
    {
        gamemanager.count = gamemanager.count + (10 * levle);
        gamemanager.UpdateUI();
    }
}
