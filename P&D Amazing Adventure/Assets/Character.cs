using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public Vector2Int location;

    // Start is called before the first frame update
    void Start()
    {
        location = new Vector2Int((int)gameObject.transform.position.x, (int)gameObject.transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Move(Vector2Int dir_)
    {
        location += dir_;
        gameObject.transform.position += (Vector3Int)(dir_ * 5);   
    }
}
