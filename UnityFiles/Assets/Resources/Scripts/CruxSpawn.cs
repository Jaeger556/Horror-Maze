using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CruxSpawn : MonoBehaviour
{
    public Transform parentObject;
    public int numObjsToActivate = 3;

    // Start is called before the first frame update
    void Start()
    {
        int childCount = parentObject.childCount;

        int[] shuffledIndices = new int[childCount];
        for (int i = 0; i < childCount; i++)
        {
            shuffledIndices[i] = i;
        }
        ShuffleArray(shuffledIndices);

        for(int i = 0; i < numObjsToActivate; i++)
        {
            int randomIndex = shuffledIndices[i];
            parentObject.GetChild(randomIndex).gameObject.SetActive(true);
        }
    }

    private void ShuffleArray<T>(T[] array)
    {
        int n = array.Length;
        while(n > 1)
        {
            int k = Random.Range(0, n--);
            T temp = array[k];
            array[k] = array[n];
            array[n] = temp;
        }
    }
}
