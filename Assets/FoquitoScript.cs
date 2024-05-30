using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoquitoScript : MonoBehaviour
{
    public GameObject[] colors;
    public int currentLightIndex =-1;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateNextLight()
    {
        currentLightIndex++;
        if (currentLightIndex >= colors.Length)
        {
            currentLightIndex = 0;
        }
        DeactivateAllLights();
        colors[currentLightIndex].SetActive(true);
        if(currentLightIndex == 0){
            lightCount++;
        }
        if(lightCount == 4){
            CancelInvoke();
            DeactivateAllLights();
        }
    }
    int lightCount = 0;
    public void ActivatePreviousLight()
    {
        currentLightIndex--;
        if (currentLightIndex < 0)
        {
            currentLightIndex = colors.Length - 1;
        }
        DeactivateAllLights();
        colors[currentLightIndex].SetActive(true);
    }

    void DeactivateAllLights()
    {
        for (int i = 0; i < colors.Length; i++)
        {
            colors[i].SetActive(false);
        }
    }
    bool Activated = false;
    public void ActivateRepeating(float t)
    {
        if (!Activated)
        {
            InvokeRepeating(nameof(ActivateNextLight),0,t);
            Activated = true;
        }        
    }
}
