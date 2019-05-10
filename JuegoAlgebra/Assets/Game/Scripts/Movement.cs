using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float limL;
    private float limR;
    private bool canLerpL;
    private bool canLerpR;
    private float time;
    private float t;
    private Vector3 dir;
    private Vector3 target;
    Rigidbody rig;
    // Start is called before the first frame update
    void Start()
    {
        limL = -3f;
        limR = 3f;
        canLerpL = false;
        canLerpR = false;
        target = transform.position;
        rig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

       // dir = transform.position - target;

       //transform.position = transform.position - dir * Time.deltaTime*80;
       // //t += Time.deltaTime;

       // //if (t<=1)
       // //{
       // //    transform.position = Vector3.Lerp(transform.position, transform.position + transform.forward, Time.deltaTime);
       // //}
       // if (Input.GetKeyDown(KeyCode.LeftArrow))
       // {
       //     //rig.AddForce(transform.forward*2, ForceMode.Impulse);
       //    target = transform.position + transform.forward * -1;
       // }
       // if (Input.GetKeyDown(KeyCode.RightArrow))
       // {
       //    target = transform.position + transform.forward;
       // }

        if (transform.position.z<limL)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, limL);
        }
        if (transform.position.z > limR)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, limR);
        }

        //if (canLerpL)
        //{
        //    time += Time.deltaTime;
        //    transform.Translate(transform.forward*-1 * Time.smoothDeltaTime, Space.World);
        //    if (time>=1)
        //    {
        //        canLerpL = false;
        //        time = 0;
        //    }
        //}
        //if (canLerpR)
        //{
        //    time += Time.deltaTime;
        //    transform.Translate(transform.forward * Time.deltaTime, Space.World);
        //    if (time >= 1)
        //    {
        //        canLerpR = false;
        //        time = 0;
        //    }
        //}
    }
}
