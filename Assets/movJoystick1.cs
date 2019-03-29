using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movJoystick1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(esperaInicial());
    }

    // Update is called once per frame
    void Update()
    {
        //Girar
        this.transform.Rotate(0f, Input.GetAxis("Horizontal1") * 4f, 0f, Space.Self);

        if (Input.GetKey(KeyCode.Joystick1Button1))
        {
            //Avanzar hacia adelante
            transform.Translate(Vector3.left * 40f * Time.deltaTime);
        }
    }

    IEnumerator desvioPorViento()
    {
        while (true)
        {
            transform.Translate(Vector3.right * 7f * Time.deltaTime);
            yield return 0;
        }
    }

    IEnumerator esperaInicial()
    {
        yield return new WaitForSeconds(3);
        StartCoroutine(desvioPorViento());
    }
}
