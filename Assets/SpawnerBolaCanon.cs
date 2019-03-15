using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBolaCanon : MonoBehaviour
{

    public GameObject bolaCanonPrefab;
    public GameObject canon;
    private AudioSource source;
    public AudioClip sonidoCanon;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //Si se presiona Espacio carga el cañon
        if (Input.GetKeyDown("space"))
        {
            //crea la bola
            GameObject bolaCanon = SpawnBolaCanon();
            DispararBolaCanon(bolaCanon);
        }
    }

    private void DispararBolaCanon(GameObject bolaCanon)
    {
        Rigidbody rbBolaCanon = bolaCanon.GetComponent<Rigidbody>();
        //rbBolaCanon.AddForce(20f, 25f, 0, ForceMode.Impulse);
        rbBolaCanon.AddForce(canon.transform.forward * 110f,ForceMode.Impulse );
        source.PlayOneShot(sonidoCanon);
    }

    public GameObject SpawnBolaCanon()
    {
        return Instantiate(bolaCanonPrefab, canon.transform.position, canon.transform.rotation);
    }
    
}
