using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : Buildings
{
    public int[] moneyIncome;
    public int[] wasteIncome;

    private bool isOn;

    override
    public void Built()
    {
        this.isOn = true;
        this.getRessources().addIncomeMoney(this.moneyIncome[0]);
        this.getRessources().addIncomeWaste(this.wasteIncome[0]);
    }

    override
    public void Upgrade()
    {
        this.getRessources().looseIncomeMoney(this.moneyIncome[this.getLvl()]);
        this.getRessources().looseIncomeWaste(this.wasteIncome[this.getLvl()]);

        this.addLvl();

        this.getRessources().addIncomeMoney(this.moneyIncome[this.getLvl()]);
        this.getRessources().addIncomeWaste(this.wasteIncome[this.getLvl()]);
    }

    override
    public void Sell()
    {
        this.getRessources().looseIncomeMoney(this.moneyIncome[this.getLvl()]);
        this.getRessources().looseIncomeWaste(this.wasteIncome[this.getLvl()]);

        Destroy(this);
    }

    override
    public void Active()
    {
        if(!this.isOn)
        {
            StartCoroutine(this.startCd());
            for (int i = 0; i <= this.getLvl(); i++)
            {
                this.getRessources().addIncomeMoney(this.moneyIncome[i]);
                this.getRessources().addIncomeWaste(this.wasteIncome[i]);
            }

            this.isOn = true;
        }
        else if(this.getOnCd() && this.isOn)
        {
            StartCoroutine(this.startCd());
            for (int i = 0; i <= this.getLvl(); i++)
            {
                this.getRessources().looseIncomeMoney(this.moneyIncome[i]);
                this.getRessources().looseIncomeWaste(this.wasteIncome[i]);
            }
            this.isOn = false;
        }
    }

    override
    public string stringUpgrade()
    {
        if (this.getMaxLvl() == this.getLvl())
        {
            return "max level reached";
        }
        int tempMoney = this.moneyIncome[this.getLvl() + 1] - this.moneyIncome[this.getLvl()];
        int tempWaste = this.wasteIncome[this.getLvl() + 1] - this.wasteIncome[this.getLvl()];
        int tempCdr = this.cd[this.getLvl() + 1] - this.cd[this.getLvl()];
        return ("+" + tempMoney + " $.s +" + tempWaste + " Waste.s -" + tempCdr + "s as cdr");
    }

    override
    public string stringActive()
    {
        if (this.isOn)
        {
            return ("Turn off the factory, cd: " + this.getCd(this.getLvl()) + "s");
        }
        return ("Turn on the factory, cd: " + this.getCd(this.getLvl()) + "s");
    }

    override
    public string stringActiveCost()
    {

        return ("" + this.getCd(this.getLvl()));
    }

    override
    public string stringUsage()
    {
        return ("Factory produce money and waste");
    }
}
