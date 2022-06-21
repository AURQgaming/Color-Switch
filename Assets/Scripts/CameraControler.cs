using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{
    public Transform player; 
    // Update is called once per frame
    void Update()
    {
        if(player.position.y > transform.position.y)
        {
            transform.position = new Vector3(transform.position.x,player.transform.position.y,transform.position.z);
        }
        
    }
}
