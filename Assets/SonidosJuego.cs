using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SonidosJuego : MonoBehaviour
{
    public AudioClip sonidoJuego;
    public AudioClip sonidoGana;
    public Text txtTiempo;
    private AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        source.PlayOneShot(sonidoJuego);
        StartCoroutine(EsperarYPintarTiempo());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void pintarMensaje(string msg)
    {
        txtTiempo.text = msg;
    }

    private void pintarTiempo(int tiempo)
    {
        txtTiempo.text = tiempo.ToString();
    }

    //Corutina para esperar un segundo para pintar tiempo
    IEnumerator EsperarYPintarTiempo()
    {
        int tiempo = 60;
        pintarMensaje("Preparados!");
        yield return new WaitForSeconds(1);
        pintarMensaje("Listos!");
        yield return new WaitForSeconds(1);
        pintarMensaje("Empieza!");
        yield return new WaitForSeconds(1);
        while (true)
        {
            yield return new WaitForSeconds(1);
            tiempo--;
            pintarTiempo(tiempo);
        }
    }
}
