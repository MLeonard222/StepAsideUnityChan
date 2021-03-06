using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCameraController : MonoBehaviour
{
    private GameObject unitychan;

    private float difference;

    void Start()
    {
        this.unitychan = GameObject.Find("unitychan");

        this.difference = unitychan.transform.position.z - this.transform.position.z;
    }

    void Update()
    {
        this.transform.position = new Vector3(0f, this.transform.position.y, this.unitychan.transform.position.z - difference);
    }
}
