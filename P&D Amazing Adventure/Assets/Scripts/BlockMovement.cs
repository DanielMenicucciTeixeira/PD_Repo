using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMovement : MonoBehaviour
{
    public Level.TileState blockType;
    public Vector2Int location;

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
        gameObject.transform.position += (Vector3Int)(dir_ * 5);
    }

    public void SetUpLocation()
    {
        location.x = (int)(gameObject.transform.position.x / 5.0f);
        location.y = (int)(gameObject.transform.position.y / 5.0f);
    }
}
