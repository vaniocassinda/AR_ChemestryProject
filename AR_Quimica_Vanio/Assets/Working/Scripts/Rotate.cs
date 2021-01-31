using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform target;
    public int speed;
    void Start()
    {
        if (target == null)
        {
            target = this.gameObject.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(target.position, target.transform.up, speed * Time.deltaTime);
    }

}
