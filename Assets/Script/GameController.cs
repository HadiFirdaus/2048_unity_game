/*
 * This script is to handle user inputs
 * This script is attached to GamePanel
 */

using UnityEngine;
using System;

public class GameController : MonoBehaviour
{
    [SerializeField]
    GameObject Fills;
    [SerializeField]
    Transform[] Cells;

    public static Action<string> slide;

    void Start()
    {
        Debug.Log("Play");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Debug.Log("Space is pressed");
            SpawnFill();
        }

        SlideMethod();

    }

    public void SpawnFill()
    {

        int whichSpawn = UnityEngine.Random.Range(0, Cells.Length);
        if (Cells[whichSpawn].childCount != 0)
        {
            Debug.Log(Cells[whichSpawn].name + " is spawned");
            SpawnFill();
            return;
        }

        float chance = UnityEngine.Random.Range(0f, 1f);
        //Debug.Log(chance);

        if (chance < 0.2f)
        {
            return;
        }
        else if (chance < 0.8f)
        {
            GameObject temp = Instantiate(Fills, Cells[whichSpawn]);
            Fill tempFillComp = temp.GetComponent<Fill>();  //tempFillComp is a local variable based of Fill class. Its job is to get the script (Fill.cs) and stored it in tempFillComp
            Cells[whichSpawn].GetComponent<Cell>().fills = tempFillComp;
            tempFillComp.FillValueUpdate(2);    //2
        }
        else
        {
            GameObject temp = Instantiate(Fills, Cells[whichSpawn]);
            Fill tempFillComp = temp.GetComponent<Fill>();
            Cells[whichSpawn].GetComponent<Cell>().fills = tempFillComp;
            tempFillComp.FillValueUpdate(4);    //4
        }
    }

    void SlideMethod()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            slide("W");
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            slide("D");
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            slide("S");
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            slide("A");
        }
    }
}
