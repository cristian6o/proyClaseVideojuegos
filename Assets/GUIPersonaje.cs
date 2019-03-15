using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIPersonaje : MonoBehaviour
{
    public Text txtSangre;
    public Personaje personaje;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        txtSangre.text = "Sangre:" + personaje.sangre;
    }
}
