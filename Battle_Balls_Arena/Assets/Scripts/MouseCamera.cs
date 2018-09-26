﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCamera : MonoBehaviour {

    public GameObject target;
    public float rotateSpeed = 5;
    Vector3 offset;
    bool rightclicked = false;
     
    void Start() {
        offset = target.transform.position - transform.position;
        PositionCamera();
    }
     
    void LateUpdate() {
        if (Input.GetMouseButton(1)) {
            PositionCamera();
        }
    }

    void PositionCamera() {
        float horizontal;

        if (target.GetComponent<Move>().IsMoving) {
            horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
            target.transform.Rotate(0, horizontal, 0);

            float desiredAngle = target.transform.eulerAngles.y;
            transform.position = target.transform.position - (offset);
        }
        else {
            horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
            target.transform.Rotate(0, horizontal, 0);

            float desiredAngle = target.transform.eulerAngles.y;
            Quaternion rotation = Quaternion.Euler(0, desiredAngle, 0);
            transform.position = target.transform.position - (rotation * offset);
        }
        
        
        
        transform.LookAt(target.transform);
    }
}
