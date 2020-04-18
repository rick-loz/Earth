using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public float duration;
    public int numberSlices;
    public Ressources ressources;
    private Slices[] slices;
    private int currentSlice;
    private float degreeRotation;

    void Start()
    {
        degreeRotation = 360 / numberSlices;
        currentSlice = 0;
        slices = new Slices[numberSlices];
        for (int i = 0; i < numberSlices; i++)
        {
            slices[i].setRessources(this.ressources); 
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void rotate(bool clockwise)
    {
        if (clockwise)
        {
            currentSlice = (currentSlice + 1) % numberSlices;
            StartCoroutine(smoothRotation(1));
        }
        else
        {
            currentSlice -= 1;
            if(currentSlice == -1) { currentSlice = 5; }
            StartCoroutine(smoothRotation(-1));
        }
    }

    public IEnumerator smoothRotation(int clockwise)
    {
        Quaternion from = transform.rotation;
        Quaternion to = transform.rotation;
        to *= Quaternion.Euler(new Vector3(0,0, from.z + (clockwise * degreeRotation)));

        float elapsed = 0.0f;
        while (elapsed < duration)
        {
            transform.rotation = Quaternion.Slerp(from, to, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.rotation = to;


    }
}
