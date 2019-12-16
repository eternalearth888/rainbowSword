using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCamera : MonoBehaviour
{
    public float turnSpeed = 4.0f;
      public Transform player;
  
      private Vector3 offset;
      public float yOff = 4f;
      public float zOff = 4f;
      private Vector3 height;
  
      void Start () {
          offset = new Vector3(player.position.x, player.position.y + yOff, player.position.z + zOff);
          height = new Vector3(10, 0, 0);
      }
  
      void LateUpdate()
      {
          offset = Quaternion.AngleAxis (Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * offset;
          transform.position = player.position + offset; 
          transform.LookAt(player.position);
          transform.rotation *= Quaternion.Euler(-20, 0, 0);
      }
}
