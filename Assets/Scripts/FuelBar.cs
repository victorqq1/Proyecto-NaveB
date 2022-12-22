using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelBar : MonoBehaviour
{
    // Start is called before the first frame update

    public Image theFuelBar;

    public float currentFuel;
    public int maxFuel;


    void Start()
    {
        currentFuel = maxFuel;
    }

    // Update is called once per frame
    void Update()
    {
        theFuelBar.fillAmount = currentFuel / maxFuel;
    }

    /*
    public void SetCurrentFuel(float f)
    {
        this.currentFuel = f;
    }
    public float GetCurrentFuel (float f)
    {
        return this.currentFuel;
    }
    */

}
