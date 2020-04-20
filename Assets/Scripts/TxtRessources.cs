using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TxtRessources : MonoBehaviour
{
    public Text textMoney;
    public Text textWaste;
    public Text textCapacity;

    public Ressources planetRessources;
    public Planet planet;
    
    void Start()
    {
        planetRessources = planet.GetComponent<Ressources>();
    }

    // Update is called once per frame
    void Update()
    {
        textMoney.text = planetRessources.getMoney().ToString();
        textWaste.text = planetRessources.getWaste().ToString();
        textCapacity.text = planet.getMaxWaste().ToString();
    }
}
