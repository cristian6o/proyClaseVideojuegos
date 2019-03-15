using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour
{
    public int sangre = 100;

    #region Mensajes Unity
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    #endregion

    public void SubirSangre()
    {
        sangre += 10;

    }

    public void BajarSangre()
    {
        sangre -= 10;
    }
}
