using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBolaCanonJoystick : MonoBehaviour
{
    public GameObject bolaCanonPrefab;
    public GameObject canon;
    private AudioSource source;
    public AudioClip sonidoCanon;
    private Boolean puedeDisparar;
    public GameObject avisoDisparo;

    // Start is called before the first frame update
    void Start()
    {
        this.puedeDisparar = true;
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //Si se presiona Espacio carga el cañon
        if (Input.GetKeyDown(KeyCode.Joystick1Button2))
        {
            //crea la bola
            if (puedeDisparar)
            {
                GameObject bolaCanon = SpawnBolaCanon();
                DispararBolaCanon(bolaCanon);
                this.puedeDisparar = false;
                avisoDisparo.GetComponent<Renderer>().enabled = false; //Ocultar
                StartCoroutine(tiempoEsperaDisparar());
            }
        }
    }

    IEnumerator tiempoEsperaDisparar()
    {
        yield return new WaitForSeconds(4);
        this.puedeDisparar = true;
        avisoDisparo.GetComponent<Renderer>().enabled = true; //Ocultar
    }

    private void DispararBolaCanon(GameObject bolaCanon)
    {
        Rigidbody rbBolaCanon = bolaCanon.GetComponent<Rigidbody>();
        //rbBolaCanon.AddForce(20f, 25f, 0, ForceMode.Impulse);
        rbBolaCanon.AddForce(canon.transform.forward * 110f, ForceMode.Impulse);
        source.PlayOneShot(sonidoCanon);
    }

    public GameObject SpawnBolaCanon()
    {
        return Instantiate(bolaCanonPrefab, canon.transform.position, canon.transform.rotation);
    }

}
