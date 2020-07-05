using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TxtWriting : MonoBehaviour
{
    public TxtRessources textRessources;
    public Text textComponent;
    public CustomEventSystem eventSystem;
    public Planet planet;

    public GameObject incineratorPrefab;
    public GameObject dumpingPrefab;
    public GameObject factoryPrefab;
    public GameObject portalPrefab;

    private string incineratorCost;
    private string dumpingCost;
    private string factoryCost;
    private string portalCost;

    private string incineratorBonus;
    private string dumpingBonus;
    private string factoryWasteBonus;
    private string factoryMoneyBonus;


    private bool menuOpen;

    void Start()
    {
        menuOpen = false;
        incineratorCost = this.incineratorPrefab.GetComponent<Recylcer>().getBuildingValue().ToString(); 
        incineratorBonus = this.incineratorPrefab.GetComponent<Recylcer>().getFirstWasteBonus().ToString();

        dumpingCost = this.dumpingPrefab.GetComponent<Dumping>().getBuildingValue().ToString();
        dumpingBonus = this.dumpingPrefab.GetComponent<Dumping>().getFirstCapacityBonus().ToString();

        factoryCost = this.factoryPrefab.GetComponent<Factory>().getBuildingValue().ToString();
        factoryWasteBonus = this.factoryPrefab.GetComponent<Factory>().getFirstWasteBonus().ToString();
        factoryMoneyBonus = this.factoryPrefab.GetComponent<Factory>().getFirstMoneyBonus().ToString();


        portalCost = this.portalPrefab.GetComponent<Portal>().getBuildingValue().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (menuOpen)
        {
            GameObject tempGameObject = this.eventSystem.currentSelectedGameObject;
            Buildings tempBuilding = this.planet.getCurrentSliceBuilding();


            if (string.Compare(tempGameObject.tag, "Active") == 0)
            {
                textComponent.text = tempBuilding.stringActive();
                textRessources.setBonusString(tempBuilding.getActiveMoneyCost(), tempBuilding.getActiveWasteCost(), tempBuilding.getActiveCapacity(),tempBuilding.getActiveMoneyIncome(),tempBuilding.getActiveWasteIncome());
            }

            else if (string.Compare(tempGameObject.tag, "Upgrade") == 0)
            {
                textComponent.text = tempBuilding.stringUpgrade();
                textRessources.setBonusString(" - " + tempBuilding.getUpgradesValue(tempBuilding.getLvl()), "", tempBuilding.getNewCapacity(), tempBuilding.getNewMoneyIncome(), tempBuilding.getNewWasteIncome());
            }
            else if (string.Compare(tempGameObject.tag, "Sell") == 0)
            {
                textComponent.text = tempBuilding.stringSell();
                textRessources.setBonusString(" + " + tempBuilding.getSellValue(), "", "", "", "");
            }
            else if (string.Compare(tempGameObject.tag, "Portal") == 0)
            {
                textComponent.text = "Portal allow you to warp trash into opponent's planet. Cost: " + this.portalCost + " $";
                textRessources.setBonusString(" - " + this.portalCost, "", "","","");
            }
            else if (string.Compare(tempGameObject.tag, "Factory") == 0)
            {
                textComponent.text = "Factory produce money and waste. Cost: " + this.factoryCost + " $";
                textRessources.setBonusString(" - " + this.factoryCost,"","", " + " + this.factoryMoneyBonus, " + " + this.factoryWasteBonus);
            }
            else if (string.Compare(tempGameObject.tag, "Dump") == 0)
            {
                textComponent.text = "Dumping Sites allow you to have more waste capacity. Cost: " + this.dumpingCost + " $";
                textRessources.setBonusString(" - " + this.dumpingCost, ""," + " + this.dumpingBonus, "" ,"");
            }
            else if (string.Compare(tempGameObject.tag, "Incinerator") == 0)
            {
                textComponent.text = "Incinerator destroy waste continously. Cost: " + this.incineratorCost + " $";
                textRessources.setBonusString(" - " + this.incineratorCost,"","","", " - " + this.incineratorBonus);
            }
            else
            {
                Debug.Log(tempGameObject.tag);
                Debug.Log(tempGameObject);
            }
        }

    }

    public void setOpen(bool pBool) { this.menuOpen = pBool; }

    public TxtRessources getTxtRessources() { return this.textRessources; }
}
