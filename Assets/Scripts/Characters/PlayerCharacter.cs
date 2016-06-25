using UnityEngine;
using System.Collections;
using System;
using SVGImporter;

public class PlayerCharacter : MonoBehaviour
{
    private string name;

    // Use this for initialization
    void Start()
    {
     //   Debug.Log(name);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void setName(string name)
    {
        this.name = name;
    }

    public string getName()
    {
        return name;
    }

}
