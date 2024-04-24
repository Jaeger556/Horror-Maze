using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TreasureManager : MonoBehaviour
{
    private int count;
    [SerializeField] TMP_Text text;

    public void UpdateTreasure()
    {
        count++;
        Destroy(gameObject);
        text.text = "Bag: " + count;
    }

    void Start()
    {
        text.text = "Bag: 0";
    }
}
