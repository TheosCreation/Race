using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjFloating : MonoBehaviour
{
    public GameObject TimeSystem;
    protected TimeSystem t;
    // Start is called before the first frame update
    void Start()
    {
        if (transform.parent != null) {
            t = GetComponentInParent<ObjFloating>().t;
        }
        else { 
            t = TimeSystem.GetComponent<TimeSystem>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = new Vector3(transform.localPosition.x,
            Mathf.Sin(transform.localPosition.x + t.time+ transform.localPosition.z)/3,
            transform.localPosition.z);
    }
}
