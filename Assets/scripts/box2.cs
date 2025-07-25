using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class box2 : MonoBehaviour
{
    private int allBalls = 15;
    public GameObject[] clones;  // Array to hold the clone objects
    public GameObject aObject;
    public float ab;
    public float aa;
    public float bb;
    public float ba;
    public float cb;
    public float ca;
    public float db;
    public float da;
    public GameObject box;
    // Start is called before the first frame update
    

    public liquidSpawner liquidSpawner;
    private int levelCount = 0;

    private int currentBalls;
    public Text[] ballCount;
    private Animator animator;
    public static bool isFinished2 = false;
    public collecter collecter;
    public bool stillIn = true;
    void Start()
    {
        aObject = box.transform.Find("balls2").gameObject;
        //animator = GetComponent<Animator>();

        //animator.updateMode = AnimatorUpdateMode.UnscaledTime;
        currentBalls = 15;
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
        animator.updateMode = AnimatorUpdateMode.UnscaledTime;
    }

    // Update is called once per frame
    void Update()
    {
        ab = liquidSpawner.room1Num[2];
        aa = liquidSpawner.room1Num[1];
        bb = liquidSpawner.room2Num[2];
        ba = liquidSpawner.room2Num[1];
        cb = liquidSpawner.room3Num[2];
        ca = liquidSpawner.room3Num[1];
        db = liquidSpawner.room4Num[2];
        da = liquidSpawner.room4Num[1];
        if (collecter.isCame && stillIn)
        {
            animator.SetBool("isCrashed", true);
            UIManager.isGameOver = true;
        }
    }
    public void StartBox2()
    {
        currentBalls = 15;
        isFinished2 = false;
        levelCount++;
        if (levelCount > 4)
        {
            levelCount = 1;
        }
        ballCount[0].text = "x15";
        ballCount[1].text = "x15";
        ballCount[2].text = "x15";
        ballCount[3].text = "x15";
        StartCoroutine("BallFlow");

    }
    IEnumerator BallFlow()
    {
        //yield return new WaitForSeconds(4f);
        float speedTemp = 0;
        float speedTemp2 = 0;
        float speedTemp3 = 0;
        float speedTemp4 = 0;
        clones = new GameObject[aObject.transform.childCount];
        for (int i = 0; i < aObject.transform.childCount; i++)
        {
            clones[i] = aObject.transform.GetChild(i).gameObject;
        }
        yield return new WaitForSeconds(0);
        float t1 = 0;
        float t2 = 0;
        float[] times = new float[allBalls];
        isFinished2 = false;


        if (levelCount == 4)
        {
            for (int i = 1; i < (clones.Length + 1); i++)
            {
                if (i == 1)
                {
                    t1 = 0;
                }
                else
                {
                    t1 = (ab / allBalls) * (i);
                    times[i - 1] = t1;

                    if (i == 0)
                    {
                        t2 = 0;
                    }
                    else
                    {
                        t2 = times[i - 1] - times[i - 2];
                    }
                }

                speedTemp = liquidSpawner.room2Speeds[i - 1];
                speedTemp2 = liquidSpawner.room3Speeds[i - 1];
                speedTemp3 = liquidSpawner.room4Speeds[i - 1];
                speedTemp4 = liquidSpawner.room1Speeds[i - 1];
                if (i == 1)
                {
                    clones[i - 1].GetComponent<Traveller>().ExitMove((t2 + aa), levelCount);
                    yield return new WaitForSeconds(t2 + aa);
                    clones[i - 1].GetComponent<Traveller>().StartRun(t2 + aa, speedTemp, speedTemp2, speedTemp3, speedTemp4, levelCount);

                }
                else
                {
                    clones[i - 1].GetComponent<Traveller>().ExitMove(t2, levelCount);
                    yield return new WaitForSeconds(t2);
                    clones[i - 1].GetComponent<Traveller>().StartRun(t2, speedTemp, speedTemp2, speedTemp3, speedTemp4, levelCount);
                }
                currentBalls--;
                ballCount[0].text = "x" + currentBalls.ToString();
            }
            stillIn = false;
            yield return new WaitForSeconds(speedTemp4 + t2 + 1);
            isFinished2 = true;
        }
        else if (levelCount == 1)
        {
            for (int i = 1; i < (clones.Length + 1); i++)
            {
                if (i == 1)
                {
                    t1 = 0;
                }
                else
                {
                    t1 = (bb / allBalls) * (i);
                    times[i - 1] = t1;

                    if (i == 0)
                    {
                        t2 = 0;
                    }
                    else
                    {
                        t2 = times[i - 1] - times[i - 2];
                    }
                }
                speedTemp = liquidSpawner.room2Speeds[i - 1];
                speedTemp2 = liquidSpawner.room3Speeds[i - 1];
                speedTemp3 = liquidSpawner.room4Speeds[i - 1];
                speedTemp4 = liquidSpawner.room1Speeds[i - 1];
                if (i == 1)
                {
                    clones[i - 1].GetComponent<Traveller>().ExitMove((t2 + ba), levelCount);
                    yield return new WaitForSeconds(t2 + ba);
                    clones[i - 1].GetComponent<Traveller>().StartRun(t2+ba, speedTemp, speedTemp2, speedTemp3, speedTemp4, levelCount);

                }
                else
                {
                    clones[i - 1].GetComponent<Traveller>().ExitMove(t2, levelCount);
                    yield return new WaitForSeconds(t2);
                    clones[i - 1].GetComponent<Traveller>().StartRun(t2, speedTemp, speedTemp2, speedTemp3, speedTemp4, levelCount);
                }
          
                //clones[i - 1].GetComponent<Traveller>().StartRun(speedTemp, speedTemp2, speedTemp3, speedTemp4, levelCount);
                currentBalls--;
                ballCount[1].text = "x" + currentBalls.ToString();
            }
            stillIn = false;
            yield return new WaitForSeconds(speedTemp+t2+1);
            //print("finished");
            isFinished2 = true;
        }
        else if (levelCount == 2)
        {
            for (int i = 1; i < (clones.Length + 1); i++)
            {
                if (i == 1)
                {
                    t1 = 0;
                }
                else
                {
                    t1 = (cb / allBalls) * (i);
                    times[i - 1] = t1;

                    if (i == 0)
                    {
                        t2 = 0;
                    }
                    else
                    {
                        t2 = times[i - 1] - times[i - 2];
                    }
                }

                speedTemp = liquidSpawner.room2Speeds[i - 1];
                speedTemp2 = liquidSpawner.room3Speeds[i - 1];
                speedTemp3 = liquidSpawner.room4Speeds[i - 1];
                speedTemp4 = liquidSpawner.room1Speeds[i - 1];
                if (i == 1)
                {
                    clones[i - 1].GetComponent<Traveller>().ExitMove((t2 +ca), levelCount);
                    yield return new WaitForSeconds(t2 + ca);
                    clones[i - 1].GetComponent<Traveller>().StartRun(t2 + ca, speedTemp, speedTemp2, speedTemp3, speedTemp4, levelCount);

                }
                else
                {
                    clones[i - 1].GetComponent<Traveller>().ExitMove(t2, levelCount);
                    yield return new WaitForSeconds(t2);
                    clones[i - 1].GetComponent<Traveller>().StartRun(t2, speedTemp, speedTemp2, speedTemp3, speedTemp4, levelCount);
                }
                currentBalls--;
                ballCount[2].text = "x" + currentBalls.ToString();

            }
            stillIn = false;
            yield return new WaitForSeconds(speedTemp2 + t2 + 1);
            isFinished2 = true;
        }
        else if (levelCount == 3)
        {
            for (int i = 1; i < (clones.Length + 1); i++)
            {
                if (i == 1)
                {
                    t1 = 0;
                }
                else
                {
                    t1 = (db / allBalls) * (i);
                    times[i - 1] = t1;

                    if (i == 0)
                    {
                        t2 = 0;
                    }
                    else
                    {
                        t2 = times[i - 1] - times[i - 2];
                    }
                }

                speedTemp = liquidSpawner.room2Speeds[i - 1];
                speedTemp2 = liquidSpawner.room3Speeds[i - 1];
                speedTemp3 = liquidSpawner.room4Speeds[i - 1];
                speedTemp4 = liquidSpawner.room1Speeds[i - 1];
                if (i == 1)
                {
                    clones[i - 1].GetComponent<Traveller>().ExitMove((t2 + da), levelCount);
                    yield return new WaitForSeconds(t2 + da);
                    clones[i - 1].GetComponent<Traveller>().StartRun(t2 + da, speedTemp, speedTemp2, speedTemp3, speedTemp4, levelCount);

                }
                else
                {
                    clones[i - 1].GetComponent<Traveller>().ExitMove(t2, levelCount);
                    yield return new WaitForSeconds(t2);
                    clones[i - 1].GetComponent<Traveller>().StartRun(t2, speedTemp, speedTemp2, speedTemp3, speedTemp4, levelCount);
                }
                currentBalls--;
                ballCount[3].text = "x" + currentBalls.ToString();
            }
            stillIn = false;
            yield return new WaitForSeconds(speedTemp3 + t2 + 1);
            isFinished2 = true;
        }
    }
}
