using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMovement : MonoBehaviour
{
    public Level.TileState blockType;
    public Vector2Int location;
    Vector3 destination;
    bool isMoving = false;
    float distanceTolerance = 0.1f;
    public float speed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving) Move();
    }

    public void Move(Vector2Int dir_)
    {
        isMoving = true;
        location += dir_;
        destination = (Vector3Int)(location * 5);
        //gameObject.transform.position += (Vector3Int)(dir_ * 5);
    }
    void Move()
    {
        if (Vector3.Distance(gameObject.transform.position, destination) <= distanceTolerance)
        {
            isMoving = false;
            gameObject.transform.position = destination;
        }
        else
        {
            gameObject.transform.position += (destination - gameObject.transform.position).normalized * speed * Time.deltaTime;
        }
    }

    public void SetUpLocation()
    {
        location.x = (int)(gameObject.transform.position.x / 5.0f);
        location.y = (int)(gameObject.transform.position.y / 5.0f);
    }
}
