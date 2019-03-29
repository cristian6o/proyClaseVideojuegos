using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ganaOponente : MonoBehaviour
{
    public AudioClip sonidoPierde;
    private AudioSource sourceAudio;
    
    // Start is called before the first frame update
    void Start()
    {
        sourceAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "oponente")
        {
            sourceAudio.PlayOneShot(sonidoPierde);
            Debug.Log("Fin del juego, el oponente gana la partida");
            Time.timeScale = 0;
        }
    }
}
