using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traveller : MonoBehaviour
{
    public Vector3[] startPoint;  // The starting position
    public Vector3[] endPoint;    // The target position
    //public float moveDuration;  // Time in seconds to move from start to end
    //public int type; // 1=blue, 2=red, 3=green, 4=yellow

    public Vector3[] insidePoints;

    private liquidSpawner liquidSpawner;
    public bool isStarted1 = false;
    public bool isStarted2 = false;
    public bool isStarted3 = false;
    public bool isStarted4 = false;
    void Start()
    {
        liquidSpawner = GameObject.Find("bg").GetComponent<liquidSpawner>();
        
        //transform.localPosition = insidePoints[0];

    }

    public void ExitMove(float duration1, int levelCount)
    {
        StartCoroutine(Exiting(duration1, levelCount));
    }

    IEnumerator Exiting(float duration1, int type)
    {
        if (type == 1)
        {
            //print(duration1);
            transform.localPosition = insidePoints[0];
            if (duration1 == 0)
            {
                duration1 = 0.1f;
            }
            float totalDistance = Vector3.Distance(insidePoints[0], startPoint[0]);
            float speed = totalDistance / duration1;
            float elapsedTime = 0f;
            yield return new WaitForSeconds(0f);
            isStarted1 = true;
            while (elapsedTime < duration1)
            {
                elapsedTime += Time.deltaTime;
                transform.localPosition = Vector3.MoveTowards(transform.localPosition, startPoint[0], speed * Time.deltaTime);
                yield return null;
            }
            //StartCoroutine(SecondMove(duration2,duration3,duration4,type));
        }
        if (type == 2)
        {
            //print(duration1);
            transform.localPosition = insidePoints[1];
            if (duration1 == 0)
            {
                duration1 = 0.1f;
            }
            float totalDistance = Vector3.Distance(insidePoints[1], startPoint[1]);
            float speed = totalDistance / duration1;
            float elapsedTime = 0f;
            yield return new WaitForSeconds(0f);
            isStarted1 = true;
            while (elapsedTime < duration1)
            {
                elapsedTime += Time.deltaTime;
                transform.localPosition = Vector3.MoveTowards(transform.localPosition, startPoint[1], speed * Time.deltaTime);
                yield return null;
            }
            //StartCoroutine(SecondMove(duration2,duration3,duration4,type));
        }
        if (type == 3)
        {
            //print(duration1);
            transform.localPosition = insidePoints[2];
            if (duration1 == 0)
            {
                duration1 = 0.1f;
            }
            float totalDistance = Vector3.Distance(insidePoints[2], startPoint[2]);
            float speed = totalDistance / duration1;
            float elapsedTime = 0f;
            yield return new WaitForSeconds(0f);
            isStarted1 = true;
            while (elapsedTime < duration1)
            {
                elapsedTime += Time.deltaTime;
                transform.localPosition = Vector3.MoveTowards(transform.localPosition, startPoint[2], speed * Time.deltaTime);
                yield return null;
            }
            //StartCoroutine(SecondMove(duration2,duration3,duration4,type));
        }
        if (type == 4)
        {
            //print(duration1);
            transform.localPosition = insidePoints[3];
            if (duration1 == 0)
            {
                duration1 = 0.1f;
            }
            float totalDistance = Vector3.Distance(insidePoints[3], startPoint[3]);
            float speed = totalDistance / duration1;
            float elapsedTime = 0f;
            yield return new WaitForSeconds(0f);
            isStarted1 = true;
            while (elapsedTime < duration1)
            {
                elapsedTime += Time.deltaTime;
                transform.localPosition = Vector3.MoveTowards(transform.localPosition, startPoint[3], speed * Time.deltaTime);
                yield return null;
            }
            //StartCoroutine(SecondMove(duration2,duration3,duration4,type));
        }

    }

    public void EnterMove(float duration1, int levelCount)
    {
        StartCoroutine(Entering(duration1, levelCount));
    }

    IEnumerator Entering(float duration1, int type)
    {
        if (type == 1)
        {
            //print(duration1);
            transform.localPosition = endPoint[0];
            if (duration1 == 0)
            {
                duration1 = 0.1f;
            }
            float totalDistance = Vector3.Distance(endPoint[0], insidePoints[1]);
            float speed = totalDistance / duration1;
            float elapsedTime = 0f;
            yield return new WaitForSeconds(0f);
            isStarted1 = true;
            while (elapsedTime < duration1)
            {
                elapsedTime += Time.deltaTime;
                transform.localPosition = Vector3.MoveTowards(transform.localPosition, insidePoints[1], speed * Time.deltaTime);
                yield return null;
            }
            //StartCoroutine(SecondMove(duration2,duration3,duration4,type));
        }

        if (type == 2)
        {
            //print(duration1);
            transform.localPosition = endPoint[1];
            if (duration1 == 0)
            {
                duration1 = 0.1f;
            }
            float totalDistance = Vector3.Distance(endPoint[1], insidePoints[2]);
            float speed = totalDistance / duration1;
            float elapsedTime = 0f;
            yield return new WaitForSeconds(0f);
            isStarted1 = true;
            while (elapsedTime < duration1)
            {
                elapsedTime += Time.deltaTime;
                transform.localPosition = Vector3.MoveTowards(transform.localPosition, insidePoints[2], speed * Time.deltaTime);
                yield return null;
            }
            //StartCoroutine(SecondMove(duration2,duration3,duration4,type));
        }

        if (type == 3)
        {
            //print(duration1);
            transform.localPosition = endPoint[2];
            if (duration1 == 0)
            {
                duration1 = 0.1f;
            }
            float totalDistance = Vector3.Distance(endPoint[2], insidePoints[3]);
            float speed = totalDistance / duration1;
            float elapsedTime = 0f;
            yield return new WaitForSeconds(0f);
            isStarted1 = true;
            while (elapsedTime < duration1)
            {
                elapsedTime += Time.deltaTime;
                transform.localPosition = Vector3.MoveTowards(transform.localPosition, insidePoints[3], speed * Time.deltaTime);
                yield return null;
            }
            //StartCoroutine(SecondMove(duration2,duration3,duration4,type));
        }

        if (type == 4)
        {
            //print(duration1);
            transform.localPosition = endPoint[3];
            if (duration1 == 0)
            {
                duration1 = 0.1f;
            }
            float totalDistance = Vector3.Distance(endPoint[3], insidePoints[0]);
            float speed = totalDistance / duration1;
            float elapsedTime = 0f;
            yield return new WaitForSeconds(0f);
            isStarted1 = true;
            while (elapsedTime < duration1)
            {
                elapsedTime += Time.deltaTime;
                transform.localPosition = Vector3.MoveTowards(transform.localPosition, insidePoints[0], speed * Time.deltaTime);
                yield return null;
            }
            //StartCoroutine(SecondMove(duration2,duration3,duration4,type));
        }
    }
    public void StartRun(float t2,float duration1, float duration2, float duration3, float duration4, int levelCount)
    {
        StartCoroutine(FirstMove(t2,duration1,duration2,duration3,duration4, levelCount));
    }
    // Update is called once per frame
 
    IEnumerator FirstMove(float t2,float duration1, float duration2, float duration3, float duration4, int type)
    {
        if(type == 1)
        {
            //print(duration1);
            transform.localPosition = startPoint[0];
            if(duration1 == 0)
            {
                duration1 = 0.1f;
            }
            float totalDistance = Vector3.Distance(startPoint[0], endPoint[0]);
            float speed = totalDistance / duration1;
            float elapsedTime = 0f;
            yield return new WaitForSeconds(0f);
            isStarted1 = true;
            while (elapsedTime < duration1)
            {
                elapsedTime += Time.deltaTime;
                transform.localPosition = Vector3.MoveTowards(transform.localPosition, endPoint[0], speed * Time.deltaTime);
                yield return null;
            }
            StartCoroutine(Entering(t2, type));
            //StartCoroutine(SecondMove(duration2,duration3,duration4,type));
        }
        else if (type == 2)
        {
            transform.localPosition = startPoint[1];
            if (duration2 == 0)
            {
                duration2 = 0.1f;
            }
            float totalDistance = Vector3.Distance(startPoint[1], endPoint[1]);
            float speed = totalDistance / duration2;
            float elapsedTime = 0f;
            yield return new WaitForSeconds(0f);
            isStarted2 = true;

            while (elapsedTime < duration2)
            {
                elapsedTime += Time.deltaTime;
                transform.localPosition = Vector3.MoveTowards(transform.localPosition, endPoint[1], speed * Time.deltaTime);
                yield return null;
            }
            StartCoroutine(Entering(t2, type));
            //StartCoroutine(ThirdMove(duration3, duration4, type));
        }

        else if (type == 3)
        {
            transform.localPosition = startPoint[2];
            if (duration3 == 0)
            {
                duration3 = 0.1f;
            }
            float totalDistance = Vector3.Distance(startPoint[2], endPoint[2]);
            float speed = totalDistance / duration3;
            float elapsedTime = 0f;
            yield return new WaitForSeconds(0f);
            isStarted3 = true;
            while (elapsedTime < duration3)
            {
                elapsedTime += Time.deltaTime;
                transform.localPosition = Vector3.MoveTowards(transform.localPosition, endPoint[2], speed * Time.deltaTime);
                yield return null;
            }
            StartCoroutine(Entering(t2, type));
            //print("third move finished");
            //StartCoroutine(FourthMove(duration4, type));
        }
        else if (type == 4)
        {
            //print("4th move");
            transform.localPosition = startPoint[3];
            if (duration4 == 0)
            {
                duration4 = 0.1f;
            }
            float totalDistance = Vector3.Distance(startPoint[3], endPoint[3]);
            float speed = totalDistance / duration4;
            float elapsedTime = 0f;
            yield return new WaitForSeconds(0f);
            isStarted4 = true;
            while (elapsedTime < duration4)
            {
                elapsedTime += Time.deltaTime;
                transform.localPosition = Vector3.MoveTowards(transform.localPosition, endPoint[3], speed * Time.deltaTime);
                yield return null;
            }
            StartCoroutine(Entering(t2, type));
            //StartCoroutine("FirstMove");
        }
    }
 
}
