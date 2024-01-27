using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{   
    ArrayList jokesListArray = new ArrayList();
    void Start()
    {
        
        string filePath = @"Assets\csv\jokeslist.csv";
        
        try
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                        jokesListArray.Add(line); // Adding each line to the ArrayList
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("The file could not be read:");
            Console.WriteLine(e.Message);
        }
    }
    private void Update()
    {
        if(GameManager.Instance.isAttacking && Input.GetMouseButtonDown(0))
        {
            Tickle();
        }

        if(GameManager.Instance.isAttacking && Input.GetMouseButtonDown(1))
        {
            Joke();
        }
    }

    private void Tickle()
    {
        Debug.Log("Tickle");

        //Add animation code
        //Make this do something
    }

    private void Joke()
    {
        Debug.Log("choosing joke");
        
        int randomInt = UnityEngine.Random.Range(0, jokesListArray.Count);

        if (randomInt >= 0 && randomInt < jokesListArray.Count)
            {
            var line = jokesListArray[randomInt]; 
            
            Debug.Log("joke chosen:");
            Debug.Log(line);
                
            }
        
        //Add animation code
        //Make this do something
    }
}
