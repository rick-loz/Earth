using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recylcer : Buildings
{
    public int[] wasteIncome;



    override
    public void Built()
    {
        this.getRessources().looseIncomeWaste(this.wasteIncome[0]);
    }

    override
    public void Upgrade()
    {
        this.getRessources().addIncomeWaste(this.wasteIncome[this.getLvl()]);
        this.addLvl();
        this.getRessources().looseIncomeWaste(this.wasteIncome[this.getLvl()]);
    }

    override
    public void Sell()
    {
        this.getRessources().addIncomeWaste(this.wasteIncome[this.getLvl()]);

        Destroy(this);
    }

    override
    public void Active()
    {
        if (this.getOnCd())
        {
            StartCoroutine(this.startCd());
            this.getRessources().looseIncomeWaste(this.wasteIncome[this.getLvl()]);
            StartCoroutine(this.startActive());
        }
    }

// ------------- Strings -------------------------------------------------------------------------//
    override
    public string stringUpgrade()
    {
        if (this.getMaxLvl() == this.getLvl())
        {
            return "max level reached";
        }
        int tempWaste = this.wasteIncome[this.getLvl() + 1] - this.wasteIncome[this.getLvl()];
        int tempCdr = this.cd[this.getLvl() + 1] - this.cd[this.getLvl()];
        return (" -" + tempWaste + " Waste.s -" + tempCdr + "s as cdr");
    }

    override
    public string stringActive()
    {
        return ("Double the waste recycled for 5seconds. Cd = " + this.getCd(this.getLvl()) + "s");
    }

    override
    public string stringActiveCost()
    {

        return ("" + this.getCd(this.getLvl()));
    }
    override
    public string stringUsage()
    {
        return ("Incinerator destroy waste continously");
    }

    public IEnumerator startActive()
    {
        float elapsed = 0.0f;
        while (elapsed < 5)
        {
            elapsed += Time.deltaTime;
            yield return null;
        }
        this.getRessources().addIncomeWaste(this.wasteIncome[this.getLvl()]);
    }

    public int getFirstWasteBonus() { return this.wasteIncome[0]; }

    override
    public string getNewWasteIncome()
    {
        int tempInt = this.wasteIncome[this.getLvl() + 1] - this.wasteIncome[this.getLvl()];
        return " + " + tempInt.ToString();
    }

    override
    public string getNewCapacity()
    {
        return "";
    }

    override
    public string getNewMoneyIncome()
    {
        return "";
    }

    override
    public string getActiveMoneyCost()
    {
        return "";
    }

    override
    public string getActiveWasteCost()
    {
        return "";
    }

    override
    public string getActiveMoneyIncome()
    {
        return "";
    }

    override
    public string getActiveWasteIncome()
    {
        return " - " + this.wasteIncome[this.getLvl()];
    }

    override
    public string getActiveCapacity()
    {
        return "";
    }
}