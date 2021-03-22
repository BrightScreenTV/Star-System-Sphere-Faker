using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rot_scrpt : MonoBehaviour
{

    public float speed;
    public float torque;

    public GameObject[] spheres;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
/*         float turn = Input.GetAxis("Horizontal");
        float upSpin = Input.GetAxis("Vertical");
        GetComponent<Rigidbody>().AddTorque(transform.up * torque * turn);
        GetComponent<Rigidbody>().AddTorque(transform.right * torque * upSpin); */
    }
}
