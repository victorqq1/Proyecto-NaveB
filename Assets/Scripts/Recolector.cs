using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum tipoRecolectable
{
    combustible
}
public class Recolector : MonoBehaviour
{
    public tipoRecolectable tipo = tipoRecolectable.combustible;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    
    }

    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
    

    /*
    void OnTriggerEnter(Collider collider)
    {
        
        if (collider.gameObject.tag == "Player")
        {
            print("Fuel picked up!");
            Destroy(gameObject);
        }
    }
    */

}
