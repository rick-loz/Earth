using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ressources : MonoBehaviour
{
    public int maxWaste;

    public int waste;
    public int money;
    public int moneyIncome;
    public int wasteIncome;

    // Start is called before the first frame update
    void Start()
    {
        waste = 0;
        money = 0;
    }

    public void addMoney(int pMoney)
    {
        this.money += pMoney;
    }

    public void looseMoney(int pMoney)
    {
        this.money -= pMoney;
    }

    public void  addWaste(int pWaste)
    {
        this.waste += pWaste;
    }

    public void looseWaste(int pWaste)
    {
        this.waste -= pWaste;
    }

    public void addIncomeMoney(int pMoney)
    {
        this.moneyIncome += pMoney;
    }

    public void looseIncomeMoney(int pMoney)
    {
        this.moneyIncome -= pMoney;
    }

    public void addIncomeWaste(int pWaste)
    {
        this.wasteIncome += pWaste;
    }

    public void looseIncomeWaste(int pWaste)
    {
        this.wasteIncome -= pWaste;
    }
}
