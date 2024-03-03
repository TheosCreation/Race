using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjFloating : MonoBehaviour
{
    private TimeSystem t;
    // Start is called before the first frame update
    void Start()
    {
        t = GetComponentInParent<TimeSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = new Vector3(transform.localPosition.x,
            Mathf.Sin(transform.localPosition.x + t.time+ transform.localPosition.z)/3,
            transform.localPosition.z);
    }
}
