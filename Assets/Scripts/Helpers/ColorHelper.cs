using UnityEngine;
using System.Collections;

public class ColorHelper : MonoBehaviour {

    public Color RandomColor()
    {
        return new Color(Random.value, Random.value, Random.value);
    }

}
