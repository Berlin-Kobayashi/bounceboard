using UnityEngine;
using System.Collections;
using System;
using SVGImporter;

public class PlayerCharacter : MonoBehaviour
{
    public Boolean facingRight = true;
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

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
          Physics2D.IgnoreCollision(other.collider,this.GetComponent<Collider2D>());
        }
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
