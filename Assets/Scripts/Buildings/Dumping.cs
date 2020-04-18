using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// not dumpling (:
public class Dumping : Buildings
{
    public int[] bonusWeight;
    public int[] activeBonusWeight;

    private int totalBonusWeight;

    override
    public void Built()
    {
        totalBonusWeight = bonusWeight[0];
        this.getParentSlice().getPlanet().setMaxWaste(totalBonusWeight + this.getParentSlice().getPlanet().getMaxWaste() );
    }

    override
    public void Upgrade()
    {
        this.addLvl();
        int tempMaxWaste = bonusWeight[this.getLvl()] - bonusWeight[this.getLvl() - 1];
        this.totalBonusWeight += tempMaxWaste;
        this.getParentSlice().getPlanet().setMaxWaste(tempMaxWaste + this.getParentSlice().getPlanet().getMaxWaste());
    }

    override
    public void Sell()
    {
        Destroy(this);
    }

    override
    public void Active()
    {
        int tempMaxWaste = activeBonusWeight[this.getLvl()];
        this.totalBonusWeight += tempMaxWaste;
        this.getParentSlice().getPlanet().setMaxWaste(tempMaxWaste + this.getParentSlice().getPlanet().getMaxWaste());
        StartCoroutine(this.startCd());
    }

    //------------- String ---------------------------------------
    override
    public string stringUpgrade()
    {
        if (this.getMaxLvl() == this.getLvl())
        {
            return "max level reached";
        }
        int tempMaxWaste = bonusWeight[this.getLvl() + 1] - bonusWeight[this.getLvl()];
        int tempActiveMaxWaste = activeBonusWeight[this.getLvl() + 1] - activeBonusWeight[this.getLvl()];
        int tempCdr = this.cd[this.getLvl() + 1] - this.cd[this.getLvl()];
        return (" +" + tempMaxWaste + " waste capacity +" + tempActiveMaxWaste + " waste capacity per active. -" + tempCdr + "s as cdr");
    }

    override
    public string stringActive()
    {
        return ("Add " + this.activeBonusWeight[this.getLvl()] + " of waste capacity. cd: " + this.getCd(this.getLvl()) + "s");
    }

    override
    public string stringUsage()
    {
        return ("Dumping Sites allow you to have more waste capacity");
    }

    override
    public string stringActiveCost()
    {
        return ( "" + this.getCd(this.getLvl()));
    }
}
