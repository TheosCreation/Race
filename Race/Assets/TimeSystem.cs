using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSystem : MonoBehaviour
{
    public float time = 0;

    void Update()
    {
        time += Time.deltaTime;
    }
}
