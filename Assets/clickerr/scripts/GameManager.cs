using System.Collections;
using System.Runtime.InteropServices;
using TMPro;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] int updatespersec = 5;
    [SerializeField] public float count = 0;
    [SerializeField] TMP_Text counttext;
    float nexttimecheck = 1f;
    [SerializeField] storeupgrtade[] storeupgrade;
    [SerializeField] TMP_Text Incometext;
    [SerializeField] public picklevel[] picklevel;
    [SerializeField] public employeeupgrade employee;
    [SerializeField] public manager manager;

    private void Start()
    {
        UpdateUI();
    }

    public void ClickAction()
    {
        count = count + picklevel[0].levle;
        
        UpdateUI();

        
    }

    public void UpdateUI()
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

            mangeing();
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

    public IEnumerator mangeing()
    {
        Debug.Log("work");
        if (employee.levle > 0)
        {
            Debug.Log("works");
            if (manager.levle > 0)
            {
                Debug.Log("working");
                float activetime = 9f;
                yield return new WaitForSeconds(activetime);
                employee.activate();
            }
        }
    }
}
