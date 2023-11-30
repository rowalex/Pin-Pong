using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playyer : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    [SerializeField] float edge;
    [SerializeField] KeyCode up = KeyCode.W;
    [SerializeField] KeyCode down = KeyCode.S;


    private void Update()
    {
        float vert = 0;


        if (Input.GetKey(up))
            vert = 1f;
        else if (Input.GetKey(down))
            vert = -1f;


        float delta = vert * speed * Time.deltaTime;

        if ( edge > Mathf.Abs(transform.position.y + delta))
        {
            transform.Translate(Vector2.up * vert * speed * Time.deltaTime);

        }

    }
}
