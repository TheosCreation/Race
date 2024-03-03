using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjFloating : MonoBehaviour
{
    public GameObject TimeSystem;
    public TimeSystem t;
    // Start is called before the first frame update
    void Start()
    {
       
        t = TimeSystem.GetComponent<TimeSystem>();
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = new Vector3(transform.localPosition.x,
            (Mathf.Sin(transform.localPosition.x + t.time+ transform.localPosition.z)/3)+transform.parent.transform.position.y,
            transform.localPosition.z);
    }
}
