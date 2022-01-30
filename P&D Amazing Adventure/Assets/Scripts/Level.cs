using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Level : MonoBehaviour
{
    public enum TileState
    {
        Empty = 0,
        Black = 1,
        White = 2,
        OutOfBound = 3
    }

    public bool twoTriangles;
    public GameObject backGround;

    public (TileState, GameObject)[] tiles;
    public int rowNumber;
    public int coloumNumber;

    public Triangle triangle1;
    public Triangle triangle2;

    public string NextLevelName;
    public string CurrentLevelName;

    // Start is called before the first frame update
    virtual protected void Start()
    {
        tiles = new (TileState, GameObject)[rowNumber * coloumNumber];

        foreach (var block in FindObjectsOfType<BlockMovement>())
        {
            block.SetUpLocation();
            AddBlock(block);
        }

        backGround.transform.localScale = new Vector3(rowNumber, coloumNumber, 1);
        backGround.transform.position = new Vector3(((rowNumber - 1) * 2.5f), ((coloumNumber - 1) * 2.5f), 0);

        FindObjectOfType<Camera>().gameObject.transform.position = new Vector3(((rowNumber - 1) * 2.5f), ((coloumNumber - 1) * 2.5f), -10);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) SceneManager.LoadScene(CurrentLevelName);
    }

    public TileState GetTileState(Vector2Int location)
    {
        if (location.x >= rowNumber || location.y >= coloumNumber || location.x < 0 || location.y < 0)
        {
            return TileState.OutOfBound;
        }

        return tiles[coloumNumber * location.x + location.y].Item1;
    }

    public void SetTileState(Vector2Int location, TileState state_)
    {
        tiles[coloumNumber * location.x + location.y].Item1 = state_;
    }

    public void MoveBlock(Vector2Int location, Vector2Int dir_)
    {
        int arrayPosition = LocationToArrayPosition(location);
        BlockMovement block = tiles[arrayPosition].Item2.GetComponent<BlockMovement>();
        block.Move(dir_);
        tiles[arrayPosition] = (TileState.Empty, null);
        tiles[LocationToArrayPosition(location + dir_)] = (block.blockType, block.gameObject);
    }

    public void AddBlock(BlockMovement block)
    {
        tiles[LocationToArrayPosition(block.location)] = (block.blockType, block.gameObject);
    }

    public int LocationToArrayPosition(Vector2Int location)
    {
        return location.x * coloumNumber + location.y;
    }

    void VictoryCheck(Vector3 p_Position, Vector3 d_Position)
    {
        if (triangle1.Victory(p_Position, d_Position))
        {
            if (twoTriangles)
            {
                if (triangle2.Victory(p_Position, d_Position))
                {
                    Victory();
                }

                //Nothing
                return;
            }
            Victory();
        }
    }

    public void VictoryCheck()
    {
        //Victory Check here
        VictoryCheck((Vector3Int) GetComponent<CharacterMovement>().P.GetComponent<Character>().location * 5, (Vector3Int)GetComponent<CharacterMovement>().D.GetComponent<Character>().location * 5);
    }

    public void Victory()
    {
        SceneManager.LoadScene(NextLevelName);
    }
}
