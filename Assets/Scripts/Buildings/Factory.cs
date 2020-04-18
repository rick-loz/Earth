using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : Buildings
{
    public int[] moneyIncome;
    public int[] wasteIncome;

    private bool isOn;
    new public void Built()
    {
        this.isOn = true;
        this.getRessources().addIncomeMoney(this.moneyIncome[0]);
        this.getRessources().addIncomeWaste(this.wasteIncome[0]);
    }

    new public void Upgrade()
    {
        this.getRessources().looseIncomeMoney(this.moneyIncome[this.getLvl()]);
        this.getRessources().looseIncomeWaste(this.wasteIncome[this.getLvl()]);

        this.addLvl();

        this.getRessources().addIncomeMoney(this.getLvl());
        this.getRessources().addIncomeWaste(this.getLvl());
    }

    new public void Sell()
    {
        this.getRessources().looseIncomeMoney(this.moneyIncome[this.getLvl()]);
        this.getRessources().looseIncomeWaste(this.wasteIncome[this.getLvl()]);

        Destroy(this);
    }

    new public void Active()
    {
        if(this.getOnCd() && !this.isOn)
        {
            StartCoroutine(this.startCd());
            this.getRessources().addIncomeMoney(this.getLvl());
            this.getRessources().addIncomeWaste(this.getLvl());
            this.isOn = true;
        }
        else if(this.getOnCd() && this.isOn)
        {
            StartCoroutine(this.startCd());
            this.getRessources().looseIncomeMoney(this.moneyIncome[this.getLvl()]);
            this.getRessources().looseIncomeWaste(this.wasteIncome[this.getLvl()]);
            this.isOn = false;
        }
    }
}
