using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selection : MonoBehaviour
{
    public Mover mover;
    public Transform[] selectionArray;
    
    [ContextMenu("Part One")]
    public void PartOne()
    {
        var selectionList = new List<Transform>()
        {
            selectionArray[0]
        };
        
        mover.CheckMoveWithHandles(selectionList);
    }
    
    [ContextMenu("Part Two")]
    public void PartTwo()
    {
        var selectionList = new List<Transform>()
        {
            selectionArray[0],
            selectionArray[1]
        };
        
        mover.CheckMoveWithHandles(selectionList);
    }
    
    [ContextMenu("Part Three")]
    public void PartThree()
    {
        var selectionList = new List<Transform>()
        {
            selectionArray[2]
        };
        
        mover.CheckMoveWithHandles(selectionList);
    }

    // [ContextMenu("Part One")]
    // public void PartOne()
    // {
    //     var selectionList = new List<Transform>()
    //     {
    //         selectionArray[0],
    //         selectionArray[1],
    //         selectionArray[2]
    //     };
    //     
    //     mover.CheckMoveWithHandles(selectionList);
    // }
    //
    // [ContextMenu("Part Two")]
    // public void PartTwo()
    // {
    //     var selectionList = new List<Transform>()
    //     {
    //         selectionArray[0],
    //         selectionArray[1],
    //         selectionArray[2],
    //         selectionArray[3],
    //         selectionArray[4],
    //         selectionArray[5]
    //     };
    //     
    //     mover.CheckMoveWithHandles(selectionList);
    // }
    //
    // [ContextMenu("Part Three")]
    // public void PartThree()
    // {
    //     var selectionList = new List<Transform>()
    //     {
    //         selectionArray[4],
    //         selectionArray[5],
    //         selectionArray[6],
    //         selectionArray[7],
    //         selectionArray[8]
    //     };
    //     
    //     mover.CheckMoveWithHandles(selectionList);
    // }
}
