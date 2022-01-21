using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{

    public Vector3 Rotation;

    void Start()
    {
        Rotation = new Vector3(0, 1, 0);
    }

    void Update()
    {
        this.transform.Rotate(Rotation* Time.deltaTime*4);
    }
}
