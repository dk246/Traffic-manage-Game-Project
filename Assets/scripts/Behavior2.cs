using System.Collections;
using UnityEngine;

public class Behavior2 : MonoBehaviour
{
    public GameObject[] driver;
    public GameObject[] blockers;

    public Vector3[] startPoint;  // The starting position
    public Vector3[] endPoint;    // The target position
    public float[] moveDuration;  // Time in seconds to move from start to end


    void Start()
    {
        //StartCoroutine(MoveOverTimeAtoBClose());
        StartCoroutine(MoveOverTime(startPoint[0], endPoint[0], moveDuration[0]));
    }


    IEnumerator MoveOverTime(Vector3 fromPosition, Vector3 toPosition, float duration)
    {
        driver[0].SetActive(true);
        driver[0].transform.position = fromPosition;

        float totalDistance = Vector3.Distance(fromPosition, toPosition);
        float speed = totalDistance / duration;
        float elapsedTime = 0f;
        yield return new WaitForSeconds(3f);
        blockers[0].SetActive(false);
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            driver[0].transform.position = Vector3.MoveTowards(driver[0].transform.position, toPosition, speed * Time.deltaTime);
            yield return null;
        }

        driver[0].transform.position = toPosition;
        blockers[0].SetActive(true);

        StartCoroutine(MoveOverTimeAtoB());
    }

    IEnumerator MoveOverTimeAtoB()
    {
        float totalDistance = Vector3.Distance(startPoint[1], endPoint[1]);

        float speed = totalDistance / moveDuration[1];

        float elapsedTime = 0f;

        yield return new WaitForSeconds(3f);
        //blockers[1].SetActive(false);
        //driver[1].SetActive(false);
        while (elapsedTime < moveDuration[1])
        {
            //print("inside loop0");
            elapsedTime += Time.deltaTime;
            driver[0].transform.position = Vector3.MoveTowards(driver[0].transform.position, endPoint[1], speed * Time.deltaTime);
            yield return null;
        }
        //blockers[1].SetActive(true);
        //driver[1].transform.position = endPoint[1];
        // driver[1].transform.position = endPoint[2];
        //blockers[0].SetActive(true);
        //driver[0].SetActive(true);
        // driver[1].SetActive(true);
        //driver[0].transform.position = startPoint[0];
        //driver[1].transform.position = startPoint[2];
        StartCoroutine(MoveOverTimeAtoBClose());
    }

    IEnumerator MoveOverTimeAtoBClose()
    {
        float totalDistance = Vector3.Distance(startPoint[2], endPoint[2]);

        float speed = totalDistance / moveDuration[1];

        float elapsedTime = 0f;

        yield return new WaitForSeconds(3f);
        blockers[1].SetActive(false);
        //driver[1].SetActive(false);
        while (elapsedTime < moveDuration[1])
        {
            //print("inside loop0");
            elapsedTime += Time.deltaTime;
            driver[0].transform.position = Vector3.MoveTowards(driver[0].transform.position, endPoint[2], speed * Time.deltaTime);
            yield return null;
        }
        blockers[1].SetActive(true);
        //driver[1].transform.position = endPoint[1];
        // driver[1].transform.position = endPoint[2];
        //blockers[0].SetActive(true);
        driver[0].SetActive(true);
        //driver[1].SetActive(true);
        driver[0].transform.position = startPoint[0];
        //driver[1].transform.position = startPoint[2];
        yield return new WaitForSeconds(2.5f);
        StartCoroutine(MoveOverTime(startPoint[0], endPoint[0], moveDuration[0]));
    }
}
