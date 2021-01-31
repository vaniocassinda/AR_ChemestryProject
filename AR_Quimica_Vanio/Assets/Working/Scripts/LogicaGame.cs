using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaGame : MonoBehaviour
{
    public GameObject Hidrogenio1;
    public GameObject Hidrogenio2;
    public GameObject plane1;
    public GameObject plane2;
    public GameObject plane3;
    public GameObject InvisivelBola1;
    public GameObject InvisivelBola2;
    public bool Hidro1 = false, Hidro2 = false;
    public GameObject H2O;
    // public GameObject H2O;
    public bool fusao;


    void Start()
    {
        Hidrogenio1.GetComponent<BoxCollider>().enabled = true;
        Hidrogenio2.GetComponent<BoxCollider>().enabled = true;
       
    }

    // Update is called once per frame

    private void Update()
    {
        if (Hidro1)
        {
            Hidrogenio1.transform.position = Vector3.Lerp(Hidrogenio1.transform.position, InvisivelBola1.transform.position, 3f * Time.deltaTime);
            
        }
        if (Hidro2)
        {
            Hidrogenio2.transform.position = Vector3.Lerp(Hidrogenio2.transform.position, InvisivelBola2.transform.position, 3f * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
       if (other.gameObject == plane1)
        {
            Hidro1 = true;
        }
        if (other.gameObject == plane3)
        {
            Hidro2 = true;
        }

        if (other.gameObject == plane1)
        {
            //Na.SetActive(false);
            //Cl.SetActive(false);
            //NaCl.SetActive(true);
            fusao = true;
            H2O.SetActive(true);
        }



    }

    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject == plane1)
        {
            Hidro1 = false;

        }
        if (other.gameObject == plane3)
        {
            Hidro2 = false;
        }

        if (other.gameObject == plane1)
        {
            //Na.SetActive(false);
            //Cl.SetActive(false);
            //NaCl.SetActive(true);
            fusao = false;
            H2O.SetActive(false);

            /* if (other.gameObject == H2O)
                 //Na.SetActive(true);
                 //Cl.SetActive(true);
                 //NaCl.SetActive(false);
                 //Debug.Log("hello"); 
                 fusao = false;*/
        }

        void FixedUpdate()
        {
            if (fusao == true)
            {

                plane2.SetActive(false);

                H2O.SetActive(true);
            }
            else if (fusao == false)
            {

                plane2.SetActive(true);

                H2O.SetActive(false);
            }
        }
    }
}
