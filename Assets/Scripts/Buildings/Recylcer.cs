using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recylcer : Buildings
{
    public int[] wasteIncome;

    new public void Built()
    {
        this.getRessources().addIncomeWaste(this.wasteIncome[0]);
    }

    new public void Upgrade()
    {
        this.getRessources().looseIncomeWaste(this.wasteIncome[this.getLvl()]);

        this.addLvl();

        this.getRessources().addIncomeWaste(this.getLvl());
    }

    new public void Sell()
    {
        this.getRessources().looseIncomeWaste(this.wasteIncome[this.getLvl()]);

        Destroy(this);
    }

    new public void Active()
    {
        if (this.getOnCd())
        {
            StartCoroutine(this.startCd());
            this.getRessources().addIncomeWaste(this.getLvl());
        }

    }
}
