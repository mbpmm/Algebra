using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float limL;
    private float limR;
    private float limLRot;
    private float limRRot;
    private float time;
    private Vector3 dir;
    private Vector3 target;
    public Vector3 pos2;
    public Quaternion rot2;
    Rigidbody rig;
    public float t;
    public float t2;
    private Steps steps;
    // Start is called before the first frame update
    void Start()
    {
        limL = -3f;
        limR = 3f;
        target = transform.position;
        rig = GetComponent<Rigidbody>();
        pos2 = transform.position;
        rot2 = transform.rotation;
        steps = GetComponent<Steps>();
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime*2f;
        t2 += Time.deltaTime *2f;
        transform.position = Vector3.Lerp(transform.position, pos2, t);
        transform.rotation = Quaternion.Lerp(transform.rotation, rot2, t2);
        if (transform.position.z<limL)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, limL);
        }
        if (transform.position.z > limR)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, limR);
        }
    }

    public void Left()
    {
        if (t >= 1f)
        {
            steps.substractStep();
            t = 0;
            pos2 = transform.position + new Vector3(0, 0, -1);
        }
        //transform.position = transform.position + new Vector3(0, 0, -1);
    }
    public void Right()
    {
        if (t>=1f)
        {
            steps.substractStep();
            t = 0;
            pos2 = transform.position + new Vector3(0, 0, 1);
        }
        
        //transform.position = transform.position + new Vector3(0, 0, 1);
    }

    public void RotateLeft()
    {
        if (t2 >= 1f)
        {
            steps.substractStep();
            t2 = 0;
            rot2 = transform.rotation * Quaternion.Euler(new Vector3(0, -90, 0));
        }
        
        //transform.Rotate(new Vector3(0, -90, 0));
    }

    public void RotateRight()
    {
        if (t2 >= 1f)
        {
            steps.substractStep();
            t2 = 0;
            rot2 = transform.rotation * Quaternion.Euler(new Vector3(0, 90, 0));
        }
        
        //transform.Rotate(new Vector3(0, 90, 0));
    }
}
