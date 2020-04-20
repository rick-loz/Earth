using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mask : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Planet planet;

    // Update is called once per frame

    void Update()
    {
        Debug.Log(250 * this.planet.getRatio());
        this.spriteRenderer.color = new Color(1, 1, 1, 0.8f * this.planet.getRatio());
    }
}
