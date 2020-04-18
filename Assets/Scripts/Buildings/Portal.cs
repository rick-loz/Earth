using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : Buildings
{
    private int[] wasteSend;
    private int[] moneyCost;

    override
    public void Built()
    {
    }

    override
    public void Upgrade()
    {
        this.addLvl();
    }

    override
    public void Sell()
    {
        Destroy(this);
    }

    override
    public void Active()
    {
        if (this.getRessources().getWaste() > wasteSend[this.getLvl()] && this.getRessources().getWaste() > moneyCost[this.getLvl()])
        this.getRessources().sendEnemy(wasteSend[this.getLvl()]);
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
        int tempMoney = this.moneyCost[this.getLvl() + 1] - this.moneyCost[this.getLvl()];
        int tempWaste = this.wasteSend[this.getLvl() + 1] - this.wasteSend[this.getLvl()];
        int tempCdr = this.cd[this.getLvl() + 1] - this.cd[this.getLvl()];
        return ("Sending cost +" + tempMoney + " $ for +" + tempWaste + " waste sent. -" + tempCdr + "s as cdr");
    }

    override
    public string stringActive()
    {
        return ("Send " + this.wasteSend[this.getLvl()] + " of waste. cd: " + this.getCd(this.getLvl()) + "s");
    }

    override
    public string stringUsage()
    {
        return ("Portal allow you to warp trash into opponent's planet");
    }

    override
    public string stringActiveCost()
    {
        return ("Cost:" + this.moneyCost[this.getLvl()] + "$ cd: " + this.getCd(this.getLvl()) + "s");
    }
}
