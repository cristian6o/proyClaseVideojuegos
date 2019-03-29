using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MEF_oponente : MonoBehaviour
{

    public GameObject oponente;

    public enum estado
    {
        Caminando,
        Golpeado,
        Pierde,
        Gana
    }

    public estado estadoActual;

    float velocidad = 7f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(esperaInicial());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        //this.gameObject.GetComponent<Renderer>().enabled = false; //Ocultar
        cambiarEstado(estado.Golpeado);
    }

    IEnumerator MEF()
    {
        while (true)
        {
            yield return StartCoroutine(estadoActual.ToString());
        }

    }

    IEnumerator esperaInicial()
    {
        yield return new WaitForSeconds(3);
        StartCoroutine(MEF());
    }

    public void cambiarEstado(estado nuevoEstado)
    {
        Debug.Log("Nuevo estado del oponente "+ nuevoEstado);
        estadoActual = nuevoEstado;
    }

    IEnumerator Caminando()
    {
        while (estadoActual == estado.Caminando)
        {
            transform.Translate(this.transform.forward * velocidad * Time.deltaTime);
            yield return 0;
        }
    }

    IEnumerator Golpeado()
    {
        while (estadoActual == estado.Golpeado)
        {
            StartCoroutine(efectoGolpe());
            Debug.Log("Estado actual oponente " + estadoActual);
            yield return new WaitForSeconds(3);
            cambiarEstado(estado.Caminando);
        }
    }

    IEnumerator efectoGolpe()
    {
        transform.Rotate(Vector3.up, 5, Space.World);
        oponente.GetComponent<Renderer>().enabled = false; //Ocultar
        yield return new WaitForSeconds(0.3f);
        transform.Rotate(Vector3.up, -10, Space.World);
        oponente.GetComponent<Renderer>().enabled = true; //Ocultar
        yield return new WaitForSeconds(0.3f);
        transform.Rotate(Vector3.up, 10, Space.World);
        oponente.GetComponent<Renderer>().enabled = false; //Ocultar
        yield return new WaitForSeconds(0.3f);
        transform.Rotate(Vector3.up, -10, Space.World);
        oponente.GetComponent<Renderer>().enabled = true; //Ocultar
        yield return new WaitForSeconds(0.3f);
        transform.Rotate(Vector3.up, 10, Space.World);
        oponente.GetComponent<Renderer>().enabled = false; //Ocultar
        yield return new WaitForSeconds(0.3f);
        transform.Rotate(Vector3.up, -5, Space.World);
        oponente.GetComponent<Renderer>().enabled = true; //Ocultar
        yield return new WaitForSeconds(0.3f);
    }
}
