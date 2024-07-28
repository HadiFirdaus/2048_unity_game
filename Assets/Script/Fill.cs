/*
 * This script is attached to Fill prefab
 */

using UnityEngine.UI;
using UnityEngine;

public class Fill : MonoBehaviour
{
    public int value;
    [SerializeField]
    Text valueDisplay;
    [Range(100,2000)]
    public float speed;
    bool hasCombined;

    public void FillValueUpdate(int valueIn)
    {
        value = valueIn;
        valueDisplay.text = value.ToString();
    }

    private void Update()
    {
        if (transform.localPosition != Vector3.zero)
        {
            hasCombined = false;
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, Vector3.zero, speed * Time.deltaTime);
        }
        else if (hasCombined == false) { 
            if (transform.parent.GetChild(0) != this.transform)
            {
                Destroy(transform.parent.GetChild(0).gameObject);
            }
            hasCombined = true;
        }
    }

    public void Double()
    {
        value *= 2;
        valueDisplay.text = value.ToString();
    }
}
