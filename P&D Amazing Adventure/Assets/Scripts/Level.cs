using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public enum TileState
    {
        Empty = 0,
        Black = 1,
        White = 2,
        OutOfBound = 3
    }

    public (TileState, GameObject)[] tiles;
    public int rowNumber;
    public int coloumNumber;

    //Constructor References
    public GameObject blackTile;
    public GameObject whiteTile;
    public GameObject emptyTile;

    // Start is called before the first frame update
    virtual protected void Start()
    {
        tiles = new (TileState, GameObject)[rowNumber * coloumNumber];
        //TODO set the starting player tiles to occupied
    }

    // Update is called once per frame
    void Update()
    {

    }

    public TileState GetTileState(Vector2Int location)
    {
        if (location.x >= rowNumber  || location.y >= coloumNumber || location.x < 0 || location.y < 0)
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
        GameObject swap = tiles[coloumNumber * location.x + location.y].Item2;
        swap.transform.position += (Vector3Int)(dir_ * 5);
        tiles[coloumNumber * location.x + location.y].Item2 = tiles[coloumNumber * (location.x + dir_.x) + (location.y + dir_.y)].Item2;
        tiles[coloumNumber * (location.x + dir_.x) + (location.y + dir_.y)].Item2 = swap;
        tiles[coloumNumber * location.x + location.y].Item2.transform.position -= (Vector3Int)(dir_ * 5);
    }

    public int GetRow()
    {
        return rowNumber;
    }

    //Function to allow for inhereting systems to add tiles.
    protected void AddTile(TileState state, GameObject block, Vector2Int location, int position)
    {
        block.transform.position = (Vector3Int)location;
        tiles[position] = (state, block);
    }


}
