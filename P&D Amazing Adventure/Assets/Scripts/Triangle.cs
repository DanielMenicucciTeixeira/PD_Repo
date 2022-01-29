using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triangle : MonoBehaviour
{
    public enum ColourType
    {
        Either = 0,
        Black = 1,
        White = 2,
    }

    public ColourType condition;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool Victory(Vector3 p_Position, Vector3 d_Position)
    {
        Vector3 pos = gameObject.transform.position;
        switch (condition)
        {
            
            case ColourType.Either:
                if(p_Position == pos || d_Position == pos)
                {
                    return true;
                }
                return false;
            case ColourType.Black:
                if (p_Position == pos)
                {
                    return true;
                }
                return false;
            case ColourType.White:
                if (d_Position == pos)
                {
                    return true;
                }
                return false;
        }
        return false;
    }

}
