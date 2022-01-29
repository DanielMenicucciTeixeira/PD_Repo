using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private enum MovementResult
    {
        Invalid = 0,
        Empty = 1,
        Push = 2
    }
    public Level level;

    public GameObject P;
    public GameObject D;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        //Used to prevent to many inputs in a frame
        if (Input.anyKeyDown)
        {
            if (P.GetComponent<Character>().IsMoving() || D.GetComponent<Character>().IsMoving()) return;
            Movement(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }
    }

    void Movement(float hDir_, float vDir_)
    {
        Vector2Int Dir = new Vector2Int();

        //Horizontal Movement
        if (hDir_ != 0) { Dir.x = (int)hDir_; }

        //Vertical Movement
        else if (vDir_ != 0) { Dir.y = (int)vDir_; }

        Vector2Int PLoc = P.GetComponent<Character>().location;
        Vector2Int DLoc = D.GetComponent<Character>().location;

        //Check if other player is there
        if (PLoc + Dir == DLoc)
        {
            //Do D's calc first instead
            PlayerMovement(Dir, D, DLoc, false);
            if (PLoc + Dir != D.GetComponent<Character>().location) { PlayerMovement(Dir, P, PLoc, true); } //If D is still there, don't move
        }
        else
        {
            PlayerMovement(Dir, P, PLoc, true);
            if (DLoc + Dir != P.GetComponent<Character>().location) { PlayerMovement(Dir, D, DLoc, false); }//If P is there, don't move
        }
    }

    //Movement resolution
    void PlayerMovement(Vector2Int dir_, GameObject obj, Vector2Int loc_, bool isBlack)
    {
        switch (MovementCheck(loc_, dir_, isBlack))
        {
            case MovementResult.Invalid:
                return;

            case MovementResult.Empty:
                obj.GetComponent<Character>().Move(dir_);
                break;

            case MovementResult.Push:
                //Push Block here
                level.MoveBlock(loc_ + dir_, dir_);

                //Move Player
                obj.GetComponent<Character>().Move(dir_);
                break;
        }
    }

    MovementResult MovementCheck(Vector2Int loc_, Vector2Int dir_, bool isBlack)
    {
        //Check if stepping out of world.

        switch (level.GetTileState(loc_ + dir_))
        {
            case Level.TileState.OutOfBound:
                return MovementResult.Invalid;

            case Level.TileState.Empty:
                return MovementResult.Empty;

            case Level.TileState.Black:
                if (isBlack)
                {
                    //Test push
                    if (level.GetTileState(loc_ + (dir_ * 2)) == Level.TileState.Empty)
                    {
                        return MovementResult.Push;
                    }
                    return MovementResult.Invalid;
                }
                return MovementResult.Empty;

            case Level.TileState.White:
                if (!isBlack)
                {
                    //Test push
                    if (level.GetTileState(loc_ + (dir_ * 2)) == Level.TileState.Empty)
                    {
                        return MovementResult.Push;
                    }
                    return MovementResult.Invalid;
                }
                return MovementResult.Empty;
        }
        return MovementResult.Empty;
    }
}
