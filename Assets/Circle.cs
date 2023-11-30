using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public class Circle : MonoBehaviour
{

    private Vector2 center = Vector2.zero;

    [SerializeField] private float power;
    private int right = 0;
    [SerializeField] private Text righttext;
    private int left = 0;
    [SerializeField] private Text lefttext;

    [SerializeField] private Button butt;

    private void Start()
    {
        StartCoroutine(launchCorutine());
        righttext.text = right.ToString();
        lefttext.text = left.ToString();
        butt.onClick.AddListener(Restart);
    }

    IEnumerator launchCorutine()
    {
        Rigidbody2D rg = GetComponent<Rigidbody2D>();
        rg.velocity = Vector3.zero;
        transform.position = center;
        yield return new WaitForSeconds(1);

        float angle = Random.Range(-45f, 45f);
        int side = Random.Range(0, 1);

        Vector3 newvect = Quaternion.AngleAxis(angle, Vector3.forward) * Vector3.right * (side == 0 ? -1 : 1);

        rg.AddForce(newvect * power);




        yield return null;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            Rigidbody2D rg = GetComponent<Rigidbody2D>();
            rg.velocity = Vector3.zero;
            Vector2 vect = transform.position - collision.transform.position;
            rg.AddForce(vect.normalized * power);
        }

        if (collision.transform.tag == "Fin")
        {
            if (transform.position.x > 0)
                right++;
            else
                left++;
            righttext.text = right.ToString();
            lefttext.text = left.ToString();

            StartCoroutine(launchCorutine());
        }
    }

    public void Restart()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
