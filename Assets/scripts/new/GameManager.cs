using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] Ball;
    public Transform[] Pot;
    public GameObject[] tempBall = new GameObject[4];
    private int allBalls = 15;
    public GameObject[] BoxA, BoxB, BoxC, BoxD;  //up, right, bottom, left

    public GameObject[] boxes;  // Parent GameObject which contains "A"
    public GameObject[] clones;  // Array to hold the clone objects
    public GameObject[] clones2;
    public GameObject[] clones3;
    public GameObject[] clones4;
    public GameObject[] aObject;

    public float Xa;


    public Traveller[] travellers;


    void Start()
    {
        aObject[0] = boxes[0].transform.Find("balls").gameObject;
        aObject[1] = boxes[1].transform.Find("balls2").gameObject;
        aObject[2] = boxes[2].transform.Find("balls3").gameObject;
        aObject[3] = boxes[3].transform.Find("balls4").gameObject;
        StartCoroutine("spawner");
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator spawner()
    {
        yield return new WaitForSeconds(0);

        for (int i = 0; i < 4; i++)
        {
            BoxA[i].SetActive(true);
            BoxB[i].SetActive(true);
            BoxC[i].SetActive(true);
            BoxD[i].SetActive(true);
        }

        for (int x = 0; x < 15; x++)
        {
            for (int y = 0; y < 4; y++)
            {

                GameObject item = Instantiate(Ball[y]);
                item.transform.SetParent(Pot[y]);
                item.transform.localPosition = Vector3.zero;
                tempBall[y] = item;
                yield return new WaitForSeconds(0.05f);
            }

        }

        for (int z = 0; z < 4; z++)
        {
            Vector3 currentPosition = tempBall[z].transform.position;
            currentPosition.x += 0.1f;
            tempBall[z].transform.position = currentPosition;
        }


        clones = new GameObject[aObject[0].transform.childCount];
        clones2 = new GameObject[aObject[1].transform.childCount];
        clones3 = new GameObject[aObject[2].transform.childCount];
        clones4 = new GameObject[aObject[3].transform.childCount];

        yield return new WaitForSeconds(1f);
        for (int i = 0; i < aObject[0].transform.childCount; i++)
        {
            clones[i] = aObject[0].transform.GetChild(i).gameObject;
            clones2[i] = aObject[1].transform.GetChild(i).gameObject;
            clones3[i] = aObject[2].transform.GetChild(i).gameObject;
            clones4[i] = aObject[3].transform.GetChild(i).gameObject;

            // Check if the clone has a Rigidbody2D component
            Rigidbody2D rb = clones[i].GetComponent<Rigidbody2D>();
            Rigidbody2D rb2 = clones2[i].GetComponent<Rigidbody2D>();
            Rigidbody2D rb3 = clones3[i].GetComponent<Rigidbody2D>();
            Rigidbody2D rb4 = clones4[i].GetComponent<Rigidbody2D>();
            if (rb != null && rb2 != null && rb3 != null && rb4 != null)
            {
                // Change the Rigidbody2D body type to Static
                rb.bodyType = RigidbodyType2D.Static;
                rb2.bodyType = RigidbodyType2D.Static;
                rb3.bodyType = RigidbodyType2D.Static;
                rb4.bodyType = RigidbodyType2D.Static;
            }
        }
        BoxA[1].SetActive(false);
        BoxA[2].SetActive(false);
        BoxB[3].SetActive(false);
        BoxB[2].SetActive(false);
        BoxC[0].SetActive(false);
        BoxC[3].SetActive(false);
        BoxD[1].SetActive(false);
        BoxD[0].SetActive(false);

    }
}
