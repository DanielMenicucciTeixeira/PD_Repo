using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Move(Vector2Int dir_)
    {
        Vector3 newLoc;
        newLoc.x = dir_.x;
        newLoc.y = dir_.y;
        newLoc.z = 0;
        gameObject.transform.position += newLoc;
    }
}
