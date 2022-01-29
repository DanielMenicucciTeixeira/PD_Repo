using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public Vector2Int location;
    public float speed = 50.0f;
    bool isMoving = false;
    Vector3 destination;
    float distanceTolerance = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        location = new Vector2Int((int)(gameObject.transform.position.x / 5.0f), (int)(gameObject.transform.position.y / 5.0f));
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving) Move();
    }

    public void Move(Vector2Int dir_)
    {
        location += dir_;
        isMoving = true;
        destination = (Vector3Int)(location * 5);
        //gameObject.transform.position += (Vector3Int)(dir_ * 5);
    }

    void Move()
    {
        if (Vector3.Distance(gameObject.transform.position, destination) <= distanceTolerance)
        {
            isMoving = false;
            gameObject.transform.position = destination;
            FindObjectOfType<Level>().VictoryCheck();
        }
        else
        {
            gameObject.transform.position += (destination - gameObject.transform.position).normalized * speed * Time.deltaTime;
        }
    }

    public bool IsMoving() { return isMoving; }
}
