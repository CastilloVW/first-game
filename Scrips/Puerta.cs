using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Puerta : MonoBehaviour
{

    private BoxCollider puerta;
    public Text msjPuerta;
    private bool interact = false;



    // Start is called before the first frame update
    void Start()
    {
        puerta = GetComponent<BoxCollider>();


    }

    // Update is called once per frame
    void Update()
    {

        if (interact)
        if (Input.GetKey(KeyCode.E))
        {
            SceneManager.LoadScene("Casa in");

        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Jugador")
        {
            //If the GameObject's name matches the one you suggest, output this message in the console
            Debug.Log("Soy sho");

            string mensaje = "Presiona E para entrar";
            msjPuerta.text = mensaje;
            interact = true;

        }

    }

    private void OnCollisionExit(Collision collision)
    {

        msjPuerta.text = "";
        interact = false;
    }

}
