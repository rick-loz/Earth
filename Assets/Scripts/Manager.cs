using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public Planet planetA;
    public Planet planetB;

    private bool planetALost;
    private bool planetBLost;

    // Update is called once per frame
    void Update()
    {
        planetALost = this.planetA.getMaxWaste() < this.planetA.ressources.getWaste();
        planetBLost = this.planetB.getMaxWaste() < this.planetB.ressources.getWaste();

        if(planetALost || planetBLost)
        {
            if (planetALost && planetBLost)
            {
                Debug.Log("Both player looses");
            }
            else if (planetALost)
            {
                Debug.Log("Player 2 win!");
            }
            else
            {
                Debug.Log("player 1 win!");
            }
        }
    }
}
