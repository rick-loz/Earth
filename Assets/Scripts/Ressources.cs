using System;
using UnityEngine;

public class Ressources : MonoBehaviour
{
    //public GameObject enemyRessourcesGameObject;
    public Ressources enemyRessources;
    public int startingMoney;

    private float elapsed;
    private int waste;
    private int money;
    private int moneyIncome;
    private int wasteIncome;

    // Start is called before the first frame update
    void Start()
    {
        //enemyRessources = this.enemyRessourcesGameObject.Find("Ressources");
        elapsed = 0;
        waste = 0;
        money = this.startingMoney;
    }

    private void Update()
    {
        elapsed += Time.deltaTime;
        if(elapsed >= 1)
        {
            money += moneyIncome;
            waste += wasteIncome;
            waste = Math.Max(0, waste);
            elapsed = 0;
        }

    }

    public int getMoney() { return money; }
    public int getWaste() { return waste; }

    public Ressources getEnemyRessources() { return this.enemyRessources; }

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

    public void sendEnemy(int pWaste)
    {
        this.waste -= pWaste;
        this.enemyRessources.addWaste(pWaste);
    }
}
