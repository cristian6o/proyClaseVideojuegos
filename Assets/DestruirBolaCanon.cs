using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirBolaCanon : MonoBehaviour
{

    private AudioSource source;
    public AudioClip sonidoCaeAlMar;
    public AudioClip sonidoGolpeaCuerda;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject otro = collision.gameObject;
        bool esEnemigo = otro.tag != "generadorEsfera";

        if(esEnemigo)
        {
            this.gameObject.GetComponent<Renderer>().enabled = false; //Ocultar
            StartCoroutine(destruirEsferaCanon(otro.tag));
        }
    }

    IEnumerator destruirEsferaCanon(string tag)
    {
        if (tag == "mar")
        {
            source.PlayOneShot(sonidoCaeAlMar);
            yield return new WaitForSeconds(2);
            Destroy(this.gameObject);
        }
        else if (tag == "cuerdaFloja")
        {
            source.PlayOneShot(sonidoGolpeaCuerda);
            yield return new WaitForSeconds(3);
            Destroy(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
