using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class liquidSpawner : MonoBehaviour
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

   

    public float[] room1Num;
    public float[] room2Num;
    public float[] room3Num;
    public float[] room4Num;


    public int type;
    //public float duration;
    public float[] room1Speeds;
    public float[] room2Speeds;
    public float[] room3Speeds;
    public float[] room4Speeds;
    void Start()
    {
        aObject[0] = boxes[0].transform.Find("balls").gameObject;
        aObject[1] = boxes[1].transform.Find("balls2").gameObject;
        aObject[2] = boxes[2].transform.Find("balls3").gameObject;
        aObject[3] = boxes[3].transform.Find("balls4").gameObject;
        StartCoroutine("spawner");

        Calculating();

        for (int i = 0; i < 16; i++)
        {
            if (i < 4)
            {
                room1Num[i] = PlayerPrefs.GetInt("key" + i);
            }
            else if (i < 8)
            {
                room2Num[i - 4] = PlayerPrefs.GetInt("key" + i);
            }
            else if (i < 12)
            {
                room3Num[i - 8] = PlayerPrefs.GetInt("key" + i);
            }
            else if (i < 16)
            {
                room4Num[i - 12] = PlayerPrefs.GetInt("key" + i);
            }
        }
    }

    public void Calculating()
    {
        float duration;
        for (int i = 0; i < 15; i++)
        {
            duration = (room2Num[0] / (15) * (i + 1)) - (room1Num[1] + (room1Num[2] / 15) * (i+1) - room1Num[3]) + room1Num[1];
            if (duration < room1Num[3])
            {
                room1Speeds[i] = room1Num[3];
            }
            else
            {
                room1Speeds[i] = duration;
            }
        }

        //float duration;
        for (int i = 0; i < 15; i++)
        {
            duration = (room3Num[0] / (15) * (i + 1)) - (room2Num[1] + (room2Num[2] / 15) * (i + 1) - room2Num[3]) + room2Num[1];
            if (duration < room1Num[3])
            {
                room2Speeds[i] = room2Num[3];
            }
            else
            {
                room2Speeds[i] = duration;
            }
        }
        //float duration;
        for (int i = 0; i < 15; i++)
        {
            duration = (room4Num[0] / (15) * (i + 1)) - (room3Num[1] + (room3Num[2] / 15) * (i + 1) - room3Num[3]) + room3Num[1];
            if (duration < room1Num[3])
            {
                room3Speeds[i] = room3Num[3];
            }
            else
            {
                room3Speeds[i] = duration;
            }
        }

        for (int i = 0; i < 15; i++)
        {
            duration = (room1Num[0] / (15 )* (i + 1)) - (room4Num[1] + (room4Num[2] / 15) * (i + 1) - room4Num[3]) + room4Num[1];
            if (duration < room4Num[3])
            {
                room4Speeds[i] = room4Num[3];
            }
            else
            {
                room4Speeds[i] = duration;
            }
        }
    }

   
    // Update is called once per frame
    void Update()
    {
        Calculating();
        for (int i = 0; i < 16; i++)
        {
            if (i < 4)
            {
                room1Num[i] = PlayerPrefs.GetInt("key" + i);
            }
            else if (i < 8)
            {
                room2Num[i - 4] = PlayerPrefs.GetInt("key" + i);
            }
            else if (i < 12)
            {
                room3Num[i - 8] = PlayerPrefs.GetInt("key" + i);
            }
            else if (i < 16)
            {
                room4Num[i - 12] = PlayerPrefs.GetInt("key" + i);
            }
        }
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
                //yield return new WaitForSeconds(0.05f);
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

  
        }
        BoxA[1].GetComponent<BoxCollider2D>().isTrigger = true;
        BoxA[2].GetComponent<BoxCollider2D>().isTrigger = true;
        BoxB[3].GetComponent<BoxCollider2D>().isTrigger = true;
        BoxB[2].GetComponent<BoxCollider2D>().isTrigger = true;
        BoxC[0].GetComponent<BoxCollider2D>().isTrigger = true;
        BoxC[3].GetComponent<BoxCollider2D>().isTrigger = true;
        BoxD[1].GetComponent<BoxCollider2D>().isTrigger = true;
        BoxD[0].GetComponent<BoxCollider2D>().isTrigger = true;

    }
}
