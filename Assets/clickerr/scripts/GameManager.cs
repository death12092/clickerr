using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] int updatespersec = 5;
    [SerializeField] float count = 0;
    [SerializeField] TMP_Text counttext;
    float nexttimecheck = 1f;
    [SerializeField] storeupgrtade[] storeupgrade;
    [SerializeField] TMP_Text Incometext;

    private void Start()
    {
        UpdateUI();
    }

    public void ClickAction()
    {
        count++;
        
        UpdateUI();

        
    }

    private void UpdateUI()
    {
        counttext.text = Mathf.RoundToInt(count).ToString() + " : rocks";
    }

    public bool purchaseaction(int cost)
    {
        if (count >= cost)
        {
            count -= cost;
            UpdateUI();
            return true;
        }
        return false;
    }

    private void Update()
    {
        if(nexttimecheck < Time.timeSinceLevelLoad)
        {
            idlecalculator();
            nexttimecheck = Time.timeSinceLevelLoad + (1f / updatespersec);
        }
        
    }

    void idlecalculator()
    {
        float sum = 0f;
        foreach (var storeupgrade in storeupgrade)
        {
            sum += storeupgrade.CalculateIncomePerSecond();

        }
        Incometext.text = sum.ToString() + "/s";
        count += sum / updatespersec;
    }
}
