using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlDeNave : MonoBehaviour
{
    Rigidbody rigidbody;
    Transform transform;
    AudioSource audiosource;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        transform = GetComponent<Transform>();
        audiosource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Time.deltaTime + "seg. " + (1.0f / Time.deltaTime) + " FPS");
        ProcesarInput();
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "ColisionSegura":
                print("Colision Segura ...");
                break;
            case "Combustible":
                print("Combustible...");
                break;
            case "Aterrizaje":
                //print("Aterrizaje...");
                SceneManager.LoadScene("Nivel2");
                break;
            default:
                //print("Muerto!!!...");
                SceneManager.LoadScene("Nivel1");
                break;
        }
        /*if (collision.gameObject.CompareTag("ColisionSegura"))
        {
            print("Colision Segura");
        }
        else if (collision.gameObject.CompareTag("ColisionPeligrosa"))
        {
            print("Colision Peligrosa...");
        }*/
    }

    private void ProcesarInput()
    {
        Propulsion();
        Rotacion();
    }

    private void Propulsion()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rigidbody.freezeRotation = true;
            //print("Propulsor...");
            rigidbody.AddRelativeForce(Vector3.up); // x=0 y=1 z=0
            if (!audiosource.isPlaying)
            {
                audiosource.Play();
            }
        }
        else
        {
            audiosource.Stop();
        }
        rigidbody.freezeRotation = false;
        //rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezePositionZ;
    }

    private void Rotacion()
    {
        if (Input.GetKey(KeyCode.D))
        {
            //print("Rotar Derecha...");
            //transform.Rotate(Vector3.back);
            var rotarDerecha = transform.rotation;
            rotarDerecha.z -= Time.deltaTime * 1;
            transform.rotation = rotarDerecha;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            //print("Rotar Izquierda...");
            //transform.Rotate(Vector3.forward);
            var rotarIzquierda = transform.rotation;
            rotarIzquierda.z += Time.deltaTime * 1;
            transform.rotation = rotarIzquierda;
        }
    }
}
