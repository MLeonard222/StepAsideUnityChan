using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjectController : MonoBehaviour
{
    private GameObject unitychan;

    // Start is called before the first frame update
    void Start()
    {
        this.unitychan = GameObject.Find("unitychan");
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.z < this.unitychan.transform.position.z - 7.0f)
        {
            Destroy(this.gameObject);
        }
    }
}
