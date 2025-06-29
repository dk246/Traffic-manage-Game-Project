using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class box1 : MonoBehaviour
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

    private int currentBalls;
    public Text[] ballCount;
    
    public static bool isFinished1 = false;

    private int levelCount = 0;

    public collecter collecter;
    public bool stillIn = true;

    private Animator animator;

    private void Awake()
    {
        
    }

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.updateMode = AnimatorUpdateMode.UnscaledTime;
        //animator = GetComponent<Animator>();
        stillIn = true ;
        aObject = box.transform.Find("balls").gameObject;

        //animator.updateMode = AnimatorUpdateMode.UnscaledTime;
        currentBalls = 15;
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
    public void StartBox1()
    {
        currentBalls = 15;
        ballCount[0].text = "x15";
        ballCount[1].text = "x15";
        ballCount[2].text = "x15";
        ballCount[3].text = "x15";

        isFinished1 = false;
        levelCount++;
        if (levelCount > 4)
        {
            levelCount = 1;
        }
        StopAllCoroutines();
        StartCoroutine("BallFlow");
 
    }
    IEnumerator BallFlow()
    {
        //yield return new WaitForSeconds(4f);
        //print("started");
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
        isFinished1 = false;

        if(levelCount == 1)
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

                speedTemp = liquidSpawner.room1Speeds[i - 1];
                speedTemp2 = liquidSpawner.room2Speeds[i - 1];
                speedTemp3 = liquidSpawner.room3Speeds[i - 1];
                speedTemp4 = liquidSpawner.room4Speeds[i - 1];
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

      

                //clones[i - 1].GetComponent<Traveller>().StartRun(t2, speedTemp, speedTemp2, speedTemp3, speedTemp4, levelCount);
                currentBalls--;
                ballCount[0].text = "x" + currentBalls.ToString();

            }
            //stillIn = false;
            stillIn = false;
            yield return new WaitForSeconds(speedTemp + t2 + 1);
            //print("finished");
            isFinished1 = true;
        }
        else if(levelCount == 2)
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


                speedTemp = liquidSpawner.room1Speeds[i - 1];
                speedTemp2 = liquidSpawner.room2Speeds[i - 1];
                speedTemp3 = liquidSpawner.room3Speeds[i - 1];
                speedTemp4 = liquidSpawner.room4Speeds[i - 1];
                if (i == 1)
                {
                    clones[i - 1].GetComponent<Traveller>().ExitMove((t2 + ba), levelCount);
                    yield return new WaitForSeconds(t2 + ba);
                    clones[i - 1].GetComponent<Traveller>().StartRun(t2 + ba, speedTemp, speedTemp2, speedTemp3, speedTemp4, levelCount);


                }
                else
                {
                    clones[i - 1].GetComponent<Traveller>().ExitMove(t2, levelCount);
                    yield return new WaitForSeconds(t2);
                    clones[i - 1].GetComponent<Traveller>().StartRun(t2, speedTemp, speedTemp2, speedTemp3, speedTemp4, levelCount);

                }
                currentBalls--;
                ballCount[1].text = "x" + currentBalls.ToString();
            }
            stillIn = false;
            yield return new WaitForSeconds(speedTemp2 + t2 + 1);
            isFinished1 = true;
        }
        else if(levelCount == 3)
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

                speedTemp = liquidSpawner.room1Speeds[i - 1];
                speedTemp2 = liquidSpawner.room2Speeds[i - 1];
                speedTemp3 = liquidSpawner.room3Speeds[i - 1];
                speedTemp4 = liquidSpawner.room4Speeds[i - 1];
                if (i == 1)
                {
                    clones[i - 1].GetComponent<Traveller>().ExitMove((t2 + ca), levelCount);
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
            yield return new WaitForSeconds(speedTemp3 + t2 + 1);
            isFinished1 = true;
        }
        else if(levelCount == 4)
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

            
                speedTemp = liquidSpawner.room1Speeds[i - 1];
                speedTemp2 = liquidSpawner.room2Speeds[i - 1];
                speedTemp3 = liquidSpawner.room3Speeds[i - 1];
                speedTemp4 = liquidSpawner.room4Speeds[i - 1];
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
            yield return new WaitForSeconds(speedTemp4 + t2 + 1);
            isFinished1 = true;
        }
       
    }
}
