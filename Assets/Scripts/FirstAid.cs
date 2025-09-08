using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class FirstAid : MonoBehaviour
{
    private readonly float turnSpeed = 5f;
    // Update is called once per frame
    private void Update()
    {
        // To rotate the object 
        transform.Rotate(0, turnSpeed * Time.deltaTime, turnSpeed * Time.deltaTime);
    }
    


}
