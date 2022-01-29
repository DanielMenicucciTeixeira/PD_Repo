using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using 

public class Level : MonoBehaviour
{
    public enum TileState
    {
        Empty = 0,
        Black = 1,
        White = 2,
        OutOfBound = 3
    }

    (TileState, Block)[] tiles;
    public int rowNumber;
    public int coloumNumber;

    // Start is called before the first frame update
    void Start()
    {
        tiles = new (TileState, Block)[rowNumber * coloumNumber];
    }

    // Update is called once per frame
    void Update()
    {

    }

    public TileState GetTileState(Vector2Int location)
    {
        if (coloumNumber * location.x + location.y < 0 || coloumNumber * location.x + location.y > rowNumber * coloumNumber)
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
        tiles[coloumNumber * location.x + location.y].Item2.Move(dir_);
    }

    public int GetRow()
    {
        return rowNumber;
    }


}
