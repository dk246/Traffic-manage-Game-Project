using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collecter : MonoBehaviour
{
    public bool isCame;
    //public collecter[] collecters = new collecter[4];

    void Start()
    {
        isCame = false;
        
        //for(int i = 0; i< collecters.Length; i++)
        //{
            //collecters[i] = 
        //}
    }


    void Update()
    {
      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if(collision.gameObject.tag == "red")
        {
            isCame = true;
            //collision.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
     
        }
        else if(collision.gameObject.tag =="green")
        {
            isCame = true;
            //collision.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
    
        }
        else if (collision.gameObject.tag == "blue")
        {
            isCame = true;
            //collision.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
       
        }
        else if(collision.gameObject.tag == "yellow")
        {
            isCame = true;
            //collision.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
     
        }
    }
}
