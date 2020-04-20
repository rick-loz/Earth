using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TxtWriting : MonoBehaviour
{
    public Text textComponent;
    public CustomEventSystem eventSystem;
    public Planet planet;
    private bool menuOpen;

    void Start()
    {
        menuOpen = false;
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
                textComponent.text = tempBuilding.stringActive() + tempBuilding.stringActiveCost();
            }
            else if (string.Compare(tempGameObject.tag, "Portal") == 0)
            {
                textComponent.text = "Portal allow you to warp trash into opponent's planet. Cost: 250 $";
            }
            else if (string.Compare(tempGameObject.tag, "Upgrade") == 0)
            {
                textComponent.text = tempBuilding.stringUpgrade() + tempBuilding.stringUpgradeCost();
            }
            else if (string.Compare(tempGameObject.tag, "Sell") == 0)
            {
                textComponent.text = tempBuilding.stringSell();
            }
            else if (string.Compare(tempGameObject.tag, "Factory") == 0)
            {
                textComponent.text = "Factory produce money and waste. Cost: 150 $ ";
            }
            else if (string.Compare(tempGameObject.tag, "Dump") == 0)
            {
                textComponent.text = "Dumping Sites allow you to have more waste capacity. Cost: 100$";
            }
            else if (string.Compare(tempGameObject.tag, "Incinerator") == 0)
            {
                textComponent.text = "Incinerator destroy waste continously. Cost: 100 $";
            }
            else
            {
                Debug.Log(tempGameObject.tag);
                Debug.Log(tempGameObject);
            }
        }
    }

    public void setOpen(bool pBool) { this.menuOpen = pBool; }
}
