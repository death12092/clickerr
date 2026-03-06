using TMPro;
using UnityEngine;

public class picklevel : MonoBehaviour
{
    public TMP_Text pricetext;
    public TMP_Text incomeinfotext;

    public GameManager gamemanager;

    public int startprice = 10;
    public float upgradePriceMultiplyer = 1.25f;
    public float rocksPerupgrade = 1.0f;
    public int levle = 1;
    public bool active;

    private int CalculatePrice()
    {
        int price = Mathf.RoundToInt(startprice * Mathf.Pow(upgradePriceMultiplyer, levle));
        return price;
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
