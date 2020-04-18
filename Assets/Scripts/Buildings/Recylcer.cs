using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recylcer : Buildings
{
    public int[] wasteRecycled;

    override
    public void Built()
    {
        this.getRessources().looseIncomeWaste(this.wasteRecycled[0]);
    }

    override
    public void Upgrade()
    {
        this.getRessources().addIncomeWaste(this.wasteRecycled[this.getLvl()]);
        this.addLvl();
        this.getRessources().looseIncomeWaste(this.wasteRecycled[this.getLvl()]);
    }

    override
    public void Sell()
    {
        this.getRessources().addIncomeWaste(this.wasteRecycled[this.getLvl()]);

        Destroy(this);
    }

    override
    public void Active()
    {
        if (this.getOnCd())
        {
            StartCoroutine(this.startCd());
            this.getRessources().looseIncomeWaste(this.wasteRecycled[this.getLvl()]);
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
        int tempWaste = this.wasteRecycled[this.getLvl() + 1] - this.wasteRecycled[this.getLvl()];
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
        return ("Recycler recycle waste continously");
    }
}