using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControlDeNave : MonoBehaviour
{
    Rigidbody rigidbody;
    Transform transform;
    AudioSource audiosource;
    string NextLevel = "Nivel2";

    public FuelBar fuelBar;

    public Text puntajeText;
    float puntaje;

    public GameObject[] lifes;
    int life;
    

    // Start is called before the first frame update
    void Start()
    {
        puntaje = 100000;
        life = lifes.Length;
        Debug.Log("initial : " + life);
        rigidbody = GetComponent<Rigidbody>();
        transform = GetComponent<Transform>();
        audiosource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Time.deltaTime + "seg. " + (1.0f / Time.deltaTime) + " FPS");
        ProcesarInput();

        puntaje -= Time.deltaTime;
        puntajeText.text = "Puntaje: " + puntaje.ToString("f0");
            
    }

    float fillFuel = 10.0f;
    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "ColisionSegura":
                //print("Colision Segura ...");
                break;
            case "Combustible":
                fuelBar.currentFuel += fillFuel;
                //print("Combustible...");
                break;
            case "Aterrizaje":
                //print("Aterrizaje...");
                CambiarNivel();
                SceneManager.LoadScene(NextLevel);
                break;
            default:
                //print("Muerto!!!...");


                puntaje -= (puntaje * 0.05f); 
                life--;
                if (life < 1 || fuelBar.currentFuel < 1)
                {
                    //Debug.Log("Die : " + life);
                    Destroy(lifes[0].gameObject);
                    SceneManager.LoadScene("Nivel1");
                }
                else if (life < 5)
                {
                    //Debug.Log("colission : " + life);
                    Destroy(lifes[life].gameObject);
                }
                //SceneManager.LoadScene("Nivel1");
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

    float consumeFuel = 0.25f;
    private void Propulsion()
    {
        if (Input.GetKey(KeyCode.Space) && fuelBar.currentFuel > 0)
        {
            rigidbody.freezeRotation = true;
            //print("Propulsor...");
            rigidbody.AddRelativeForce(Vector3.up); // x=0 y=1 z=0


            if (!audiosource.isPlaying)
            {
                audiosource.Play();
            }

            fuelBar.currentFuel -= consumeFuel;
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

    void CambiarNivel()
    {
        string levelName = Application.loadedLevelName;
        if (levelName == "Nivel1")
        {
            NextLevel = "Nivel2";
            //print(NextLevel);
        }
        else if (levelName == "Nivel2")
        {
            NextLevel = "Nivel3";
            //print(NextLevel);
        }
        else if (levelName == "Nivel3")
        {
            NextLevel = "Nivel4";
            //print(NextLevel);
        }            
        else if (levelName == "Nivel4")
        {
            NextLevel = "Nivel5";
            //print(NextLevel);
        }            
        else if (levelName == "Nivel5")
        {
            NextLevel = "Nivel5";
            //print(NextLevel);
        }

        print(NextLevel);
    }
}
