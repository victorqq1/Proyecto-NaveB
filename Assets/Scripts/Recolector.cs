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
    AudioSource audiosource;
    // Start is called before the first frame update
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    /*
    private void OnCollisionEnter(Collision collision)
    {
        if (!audiosource.isPlaying)
        {
            audiosource.Play();
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
    *
    
    /*
    private void OnTriggerEnter(Collider other)
    {
        print("Colision");
        if(other.gameObject.CompareTag("Player"))
        {
            Destroy(other.gameObject);
        }
    }
    */
}
