/*
 * This script is attached to Cell prefab
 */

using UnityEngine;

public class Cell : MonoBehaviour
{
    public Cell Up;
    public Cell Left;
    public Cell Down;
    public Cell Right;

    public Fill fills;

    private void OnEnable()
    {
        GameController.slide += OnSlide;
    }

    private void OnDisable()
    {
        GameController.slide -= OnSlide;
    }

    private void OnSlide(string whatWasSent)
    {
        // Debug.Log(whatWasSent);
        if (whatWasSent == "W" || whatWasSent=="w")
        {
            if (Up != null)  //assure that it isn't the top cells
            {
                return;
            }
            else
            {
                Cell currentCell = this;
                SlideUp(currentCell);
            }
        }
        else if (whatWasSent == "A" || whatWasSent == "a")
        {
            if (Left != null)  //assure that it isn't the top cells
            {
                return;
            }
            else
            {
                Cell currentCell = this;
                SlideLeft(currentCell);
            }
        }
        else if (whatWasSent == "S" || whatWasSent == "s")
        {
            if (Down != null)  //assure that it isn't the top cells
            {
                return;
            }
            else
            {
                Cell currentCell = this;
                SlideDown(currentCell);
            }
        }
        else if (whatWasSent == "D" || whatWasSent == "d")
        {
            if (Right != null)  //assure that it isn't the top cells
            {
                return;
            }
            else
            {
                Cell currentCell = this;
                SlideRight(currentCell);
            }
        }
    }

    //=============================================================================================================================================================
    void SlideUp(Cell currentCell)
    {
        // Debug.Log(currentCell.gameObject);
        if (currentCell.Down == null)
        {
            return;
        }
        if (currentCell != null)
        {
            Cell nextCell = currentCell.Down;
            while (nextCell.Down != null && nextCell.fills == null)
            {
                nextCell = nextCell.Down;
            }
            if (nextCell.fills != null)
            {
                if (currentCell.fills.value == nextCell.fills.value)    //handle the condition where its fill is the same value
                {
                    Debug.Log("Doubled");
                    currentCell.fills.Double();
                    nextCell.fills.transform.parent = currentCell.transform;
                    currentCell.fills = nextCell.fills;
                    nextCell.fills = null;
                }
                else if(currentCell.Down.fills!=nextCell.fills)
                {                                                       //its fill is not the same value
                    Debug.Log("!doubled");  
                    nextCell.fills.transform.parent = currentCell.Down.transform;
                    currentCell.fills = nextCell.fills;
                    nextCell.fills = null;
                }
            }
        }
        else
        {
            Cell nextCell = currentCell.Down;
            while(nextCell.Down !=null && currentCell.fills == null)
            {
                nextCell = nextCell.Down;
            }
            if (nextCell.fills != null)
            {
                nextCell.fills.transform.parent = currentCell.transform;
                currentCell.fills = nextCell.fills;
                nextCell.fills = null;
                SlideUp(currentCell);
                // Debug.Log("Slide to Empty");
            }
        }

        if (currentCell.Down == null)   //assure that it is the bottom cell. if true, go rerun the code.
        {
            return;
        }
        else
        {
            SlideUp(currentCell.Down);
        }
    }

    //=============================================================================================================================================================
    void SlideDown(Cell currentCell) {
        //Debug.Log(currentCell.gameObject.name + " is Spawned");
        if (currentCell.Up == null)
        {
            return;
        }
        if (currentCell != null)
        {
            Cell nextCell = currentCell.Up;
            while (nextCell.Up != null && nextCell.fills == null)
            {
                nextCell = nextCell.Up;
            }
            if (nextCell.fills != null)
            {
                if (currentCell.fills.value == nextCell.fills.value)    //handle the condition where its fill is the same value
                {
                    currentCell.fills.Double();
                    nextCell.fills.transform.parent = currentCell.transform;
                    currentCell.fills = nextCell.fills;
                    nextCell.fills = null;
                }
                else if (currentCell.Up.fills != nextCell.fills)
                {                                                       //its fill is not the same value
                    // Debug.Log("!doubled");
                    nextCell.fills.transform.parent = currentCell.Up.transform;
                    currentCell.fills = nextCell.fills;
                    nextCell.fills = null;
                }
            }
        }
        else
        {
            Cell nextCell = currentCell.Up;
            while (nextCell.Up != null && currentCell.fills == null)
            {
                nextCell = nextCell.Up;
            }
            if (nextCell.fills != null)
            {
                nextCell.fills.transform.parent = currentCell.transform;
                currentCell.fills = nextCell.fills;
                nextCell.fills = null;
                SlideDown(currentCell);
                // Debug.Log("Slide to Empty");
            }
        }

        if (currentCell.Up == null)   //assure that it is the bottom cell. if true, go rerun the code.
        {
            return;
        }
        else
        {
            SlideDown(currentCell.Up);
        }
    }

    //=============================================================================================================================================================
    void SlideRight(Cell currentCell)
    {

        //Debug.Log(currentCell.gameObject);
        if (currentCell.Left == null)
        {
            return;
        }
        if (currentCell != null)
        {
            Cell nextCell = currentCell.Left;
            while (nextCell.Left != null && nextCell.fills == null)
            {
                nextCell = nextCell.Left;
            }
            if (nextCell.fills != null)
            {
                if (currentCell.fills.value == nextCell.fills.value)    //handle the condition where its fill is the same value
                {
                    currentCell.fills.Double();
                    nextCell.fills.transform.parent = currentCell.transform;
                    currentCell.fills = nextCell.fills;
                    nextCell.fills = null;
                }
                else if (currentCell.Left.fills != nextCell.fills)
                {                                                       //its fill is not the same value
                    // Debug.Log("!doubled");
                    nextCell.fills.transform.parent = currentCell.Left.transform;
                    currentCell.fills = nextCell.fills;
                    nextCell.fills = null;
                }
            }
        }
        else
        {
            Cell nextCell = currentCell.Left;
            while (nextCell.Left != null && currentCell.fills == null)
            {
                nextCell = nextCell.Left;
            }
            if (nextCell.fills != null)
            {
                nextCell.fills.transform.parent = currentCell.transform;
                currentCell.fills = nextCell.fills;
                nextCell.fills = null;
                SlideRight(currentCell);
                // Debug.Log("Slide to Empty");
            }
        }

        if (currentCell.Left == null)   //assure that it is the bottom cell. if true, go rerun the code.
        {
            return;
        }
        else
        {
            SlideRight(currentCell.Left);
        }
    }

    //=============================================================================================================================================================
    void SlideLeft(Cell currentCell) {

        //Debug.Log(currentCell.gameObject);
        if (currentCell.Right == null)
        {
            return;
        }
        if (currentCell != null)
        {
            Cell nextCell = currentCell.Right;
            while (nextCell.Right != null && nextCell.fills == null)
            {
                nextCell = nextCell.Right;
            }
            if (nextCell.fills != null)
            {
                if (currentCell.fills.value == nextCell.fills.value)    //handle the condition where its fill is the same value
                {
                    currentCell.fills.Double();
                    nextCell.fills.transform.parent = currentCell.transform;
                    currentCell.fills = nextCell.fills;
                    nextCell.fills = null;
                }
                else if (currentCell.Right.fills != nextCell.fills)
                {                                                       //its fill is not the same value
                    // Debug.Log("!doubled");
                    nextCell.fills.transform.parent = currentCell.Right.transform;
                    currentCell.fills = nextCell.fills;
                    nextCell.fills = null;
                }
            }
        }
        else
        {
            Cell nextCell = currentCell.Right;
            while (nextCell.Right != null && currentCell.fills == null)
            {
                nextCell = nextCell.Right;
            }
            if (nextCell.fills != null)
            {
                nextCell.fills.transform.parent = currentCell.transform;
                currentCell.fills = nextCell.fills;
                nextCell.fills = null;
                SlideLeft(currentCell);
                // Debug.Log("Slide to Empty");
            }
        }

        if (currentCell.Right == null)   //assure that it is the bottom cell. if true, go rerun the code.
        {
            return;
        }
        else
        {
            SlideLeft(currentCell.Right);
        }
    }
}
