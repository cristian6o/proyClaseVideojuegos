using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovBote : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(desvioPorViento());
    }

    // Update is called once per frame
    void Update()
    {
        //Si se presiona Left Arrow
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //Girar a la izquierda
            this.transform.Rotate(0f, -4f, 0f, Space.Self);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //Girar a la derecha
            this.transform.Rotate(0f, 4f, 0f, Space.Self);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            //Avanzar hacia adelante
            transform.Translate(Vector3.left * 25f * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            //Avanzar hacia atrás
            transform.Translate(Vector3.right * 25f * Time.deltaTime);

        }
    }

    IEnumerator desvioPorViento()
    {
        while(true)
        {
            transform.Translate(Vector3.right * 7f * Time.deltaTime);
            yield return 0;
        }
    }
}
