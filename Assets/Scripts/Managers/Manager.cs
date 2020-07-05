using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public Planet planetA;
    public Planet planetB;

    private bool planetALost;
    private bool planetBLost;

    public Image spriteRendererP1;
    public Image spriteRendererP2;

    private SpriteRenderer winnerSprite;
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
                StartCoroutine(victoryScreen(this.spriteRendererP2));
            }
            else
            {
                Debug.Log("player 1 win!");
                StartCoroutine(victoryScreen(this.spriteRendererP1));
            }
        }
    }

    public IEnumerator victoryScreen(Image pRenderer)
    {
        float elapsed = 0.0f;
        while (elapsed < 5f)
        {
            pRenderer.color = new Color(1, 1, 1, elapsed / 5f);
            elapsed += Time.deltaTime;
            yield return null;
        }
        SceneManager.LoadScene(0);
    }
}
