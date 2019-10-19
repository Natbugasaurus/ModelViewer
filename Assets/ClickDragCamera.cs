using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickDragCamera : MonoBehaviour {
    public Transform target;
    public float rotateSpeed;

    float x = 0.0f;
    float y = 0.0f;

    public float yMin, yMax;

    public bool invertY;

    private Vector3 offset;

    void Start() {
        offset = transform.position - target.transform.position;
    }

    void Update() {
        if (Input.GetMouseButton(0)) {
            x += Input.GetAxis("Mouse X") * rotateSpeed;

            if (invertY) {
                y += Input.GetAxis("Mouse Y") * rotateSpeed;
            } else {
                y -= Input.GetAxis("Mouse Y") * rotateSpeed;
            }
        }

        //y = Mathf.Clamp(y, yMin, yMax);

        Quaternion rotation = Quaternion.Euler(y, x, 0);
        transform.rotation = rotation;

        transform.position = Vector3.Lerp(transform.position, rotation * offset + target.transform.position, 0.5f);
        transform.LookAt(target);

        offset.z += Input.mouseScrollDelta.y;

        if (Input.GetKeyDown(KeyCode.Y)) {
            invertY = !invertY;
        }
    }
}
