using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform[] wayPoints;
    public float moveSpeed;
    private int currentPoints;

    public GameObject H;
    public GameObject H_1;

    public bool H_obj = false;
    public bool H1_obj = false;

    public GameObject obj;
    public Animator ani;


    void Start()
    {
        obj.SetActive(false);

        ani.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (H.transform.position == wayPoints[currentPoints].position || H_1.transform.position == wayPoints[currentPoints].position)
        {
            currentPoints++;
        }
        if(currentPoints >= wayPoints.Length)
        {
            currentPoints = 0;
        }

        if (H_obj == true)
        {
            H.transform.position = Vector3.MoveTowards(H.transform.position, wayPoints[0].position, moveSpeed * Time.deltaTime);
        }
       
      
        if(H1_obj == true)
        {
            H_1.transform.position = Vector3.MoveTowards(H_1.transform.position, wayPoints[1].position, moveSpeed * Time.deltaTime);
        }
       

        if (H_obj == true && H1_obj == true)
        {
            StartCoroutine(Dealy());
        }

    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.transform.tag == "H")
        {
            Debug.Log("hit");
            H_obj = true;
        }

        if (other.transform.tag == "H_1")
        {
            Debug.Log("hit_1");
            H1_obj = true;

        }

    }

  

    IEnumerator Dealy()
    {
        yield return new WaitForSeconds(10f);
        obj.SetActive(true);
        ani.enabled = true;

    }
}
