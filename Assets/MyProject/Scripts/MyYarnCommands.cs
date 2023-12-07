using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class MyYarnCommands : MonoBehaviour
{

    public InMemoryVariableStorage yarnInMemoryVariableStorage;

    public Material soft, medium, hard;

    public GameObject[] Tyres;






    void Start()
    {
        
    }


    void Update()
    {
        
    }


    [YarnCommand("change_tyres")]
    public void changeTyres()
    {
        string tyreNumber;
        yarnInMemoryVariableStorage.TryGetValue("$tyreNumber", out tyreNumber);

        string tyreChoice = "";

        if (tyreNumber == "1")
        {
            yarnInMemoryVariableStorage.TryGetValue("$tyreChoice1", out tyreChoice);
        }
        else if (tyreNumber == "2")
        {
            yarnInMemoryVariableStorage.TryGetValue("$tyreChoice2", out tyreChoice);
        }
        else if (tyreNumber == "3")
        {
            yarnInMemoryVariableStorage.TryGetValue("$tyreChoice3", out tyreChoice);
        }
        else
        {
            Debug.LogError("error finding tyre number");
        }



        if (tyreChoice == "softs")
        {
            for (int i = 0; i < Tyres.Length; i++)
            {
                Tyres[i].GetComponent<MeshRenderer>().enabled = true;
                Tyres[i].GetComponent<MeshRenderer>().material = soft;
            }
        }
        else if (tyreChoice == "mediums")
        {
            for (int i = 0; i < Tyres.Length; i++)
            {
                Tyres[i].GetComponent<MeshRenderer>().enabled = true;
                Tyres[i].GetComponent<MeshRenderer>().material = medium;
            }
        }
        else if (tyreChoice == "hards")
        {
            for (int i = 0; i < Tyres.Length; i++)
            {
                Tyres[i].GetComponent<MeshRenderer>().enabled = true;
                Tyres[i].GetComponent<MeshRenderer>().material = hard;
            }
        }
        else
        {
            Debug.LogError("error: could not find tyre choice");
        }
    }
}
