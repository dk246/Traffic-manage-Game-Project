using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class flow4 : MonoBehaviour
{

    private int allBalls = 15;
    public GameObject[] BoxA, BoxB, BoxC, BoxD;  //up, right, bottom, left
    public GameObject[] boxes;  // Parent GameObject which contains "A"
    public GameObject[] clones;  // Array to hold the clone objects
    public float Xa, Ya, Za;
    public Traveller[] travellers;
    public GameObject aObject;

    private bool OnlyIfStart = true;
    void Start()
    {
        for (int i = 0; i < travellers.Length; i++)
        {
            travellers[i].GetComponent<BoxCollider2D>().enabled = false;
        }
        aObject = boxes[2].transform.Find("balls3").gameObject;
        StartCoroutine("BallFlow");

    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator BallFlow()
    {
        if (OnlyIfStart)
        {
            yield return new WaitForSeconds(4f);
        }
        else
        {
            yield return new WaitForSeconds(0f);
        }
        clones = new GameObject[aObject.transform.childCount];
        for (int i = 0; i < aObject.transform.childCount; i++)
        {
            clones[i] = aObject.transform.GetChild(i).gameObject;
        }
        yield return new WaitForSeconds(0);
        float t1 = 0;
        float t2 = 0;
        float[] times = new float[allBalls];

        for (int i = 0; i < clones.Length; i++)
        {
            if (i == clones.Length - 1)
            {
                t1 = Xa;

            }
            else
            {
                t1 = Xa - Xa / allBalls * (15 - i);
            }
            times[i] = t1;

            if (i == 0)
            {
                t2 = 0;
            }
            else
            {
                t2 = times[i] - times[i - 1];
            }
            yield return new WaitForSeconds(t2);
            clones[i].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            //clones2[i].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            //clones3[i].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            //clones4[i].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            travellers[i].GetComponent<BoxCollider2D>().enabled = true;
            //travellers[i].StartRun(Za);
            OnlyIfStart = false;
        }
        StartCoroutine("BallFlow");


    }


}
