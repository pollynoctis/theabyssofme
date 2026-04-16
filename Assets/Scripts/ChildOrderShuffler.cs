using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class ChildOrderShuffler : MonoBehaviour
{
    [SerializeField] private int shuffleDepth = 20;
    
    private void Start()
    {
        Shuffle(shuffleDepth);
    }

    private void Shuffle(int depth)
    {
        for (int i = 0; i < depth; i++)
        {
            transform.GetChild(Random.Range(0, transform.childCount)).SetSiblingIndex(0);
        }
    }
}
