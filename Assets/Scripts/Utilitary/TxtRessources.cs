using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TxtRessources : MonoBehaviour
{
    public Text textMoney;
    public Text textWaste;
    public Text textCapacity;
    public Text textMoneyIncome;
    public Text textWasteIncome;

    public Ressources planetRessources;
    public Planet planet;

    private string bonusMoneyString;
    private string bonusWasteString;
    private string bonusMoneyIncomeString;
    private string bonusWasteIncomeString;
    private string bonusCapacityString;

    void Start()
    {
        bonusMoneyIncomeString = "";
        bonusWasteIncomeString = "";
        bonusCapacityString = "";
        planetRessources = planet.GetComponent<Ressources>();
    }

    // Update is called once per frame
    void Update()
    {
        textMoney.text = planetRessources.getMoney().ToString() + bonusMoneyString;
        textWaste.text = planetRessources.getWaste().ToString() + bonusWasteString;
        textCapacity.text = planet.getMaxWaste().ToString() + bonusCapacityString;
        textMoneyIncome.text = planetRessources.getMoneyIncome().ToString() + bonusMoneyIncomeString;
        textWasteIncome.text = planetRessources.getWasteIncome().ToString() + bonusWasteIncomeString;
    }

    public void setBonusString(string pMoneyBonus, string pWasteBonus, string pCapacityBonus, string pMoneyIncomeBonus, string pWasteIncomeBonus)
    {
        if (pMoneyBonus == "")
        {
            this.bonusMoneyString = "";
        }
        else
            this.bonusMoneyString = pMoneyBonus;

        if (pWasteBonus == "")
        {
            this.bonusWasteString = "";
        }
        else
            this.bonusWasteString = pWasteBonus;

        if (pCapacityBonus == "")
        {
            this.bonusCapacityString = "";
        }
        else
            this.bonusCapacityString = pCapacityBonus;

        if (pMoneyIncomeBonus == "")
        {
            this.bonusMoneyIncomeString = "";
        }
        else
            this.bonusMoneyIncomeString = pMoneyIncomeBonus;

        if (pWasteIncomeBonus == "")
        {
            this.bonusWasteIncomeString = "";
        }
        else
            this.bonusWasteIncomeString = pWasteIncomeBonus;

    }
}
