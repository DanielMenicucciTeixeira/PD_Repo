using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_Level : Level
{

    // Start is called before the first frame update
    protected override void Start()
    {
        tiles = new (TileState, GameObject)[rowNumber * coloumNumber];

        //Create Level Here
        AddTile(TileState.Empty, Instantiate(emptyTile), new Vector2Int(0, 0), 0);
        AddTile(TileState.White, Instantiate(whiteTile), new Vector2Int(0, 5), 1);
        AddTile(TileState.Empty, Instantiate(emptyTile), new Vector2Int(0, 10), 2);
        AddTile(TileState.Empty, Instantiate(emptyTile), new Vector2Int(0, 15), 3);
        AddTile(TileState.Black, Instantiate(blackTile), new Vector2Int(5, 0), 4);
        AddTile(TileState.Empty, Instantiate(emptyTile), new Vector2Int(5, 5), 5);
        AddTile(TileState.Empty, Instantiate(emptyTile), new Vector2Int(5, 10), 6);
        AddTile(TileState.Empty, Instantiate(emptyTile), new Vector2Int(5, 15), 7);
        AddTile(TileState.Empty, Instantiate(emptyTile), new Vector2Int(10, 0), 8);
        AddTile(TileState.Empty, Instantiate(emptyTile), new Vector2Int(10, 5), 9);
        AddTile(TileState.Empty, Instantiate(emptyTile), new Vector2Int(10, 10), 10);
        AddTile(TileState.Empty, Instantiate(emptyTile), new Vector2Int(10, 15), 11);
        AddTile(TileState.Empty, Instantiate(emptyTile), new Vector2Int(15, 0), 12);
        AddTile(TileState.Empty, Instantiate(emptyTile), new Vector2Int(15, 5), 13);
        AddTile(TileState.Empty, Instantiate(emptyTile), new Vector2Int(15, 10), 14);
        AddTile(TileState.Empty, Instantiate(emptyTile), new Vector2Int(15, 15), 15);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
