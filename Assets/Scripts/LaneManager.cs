using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LaneManager : MonoBehaviour
{
    private float[] lanes = new float[] { -3f, 0f, 3f };
    private bool[] laneStatus = new bool[] { false, false, false };
    public float GetFreeLane()
    {
        List<int> freeLanes = new List<int>();
        for (int i = 0; i < laneStatus.Length; i++)
        {
            if (!laneStatus[i])
            {
                freeLanes.Add(i);
            }
        }

        if (freeLanes.Count == 0)
        {
            return float.NaN;
        }

        int laneIndex = freeLanes[UnityEngine.Random.Range(0, freeLanes.Count)];
        laneStatus[laneIndex] = true;
        return lanes[laneIndex];
    }

    public void FreeLane(float lane)
    {
        int laneIndex = Array.IndexOf(lanes, lane);
        if (laneIndex != -1)
        {
            laneStatus[laneIndex] = false;
        }
    }
}
