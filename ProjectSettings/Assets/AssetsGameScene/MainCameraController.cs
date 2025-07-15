using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraController : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    Vector3 offset;

    // Start is called before the first frame update
    void Start() {
        offset = transform.position - playerTransform.position;
    }

    // Update is called once per frame
    void LateUpdate() {
        transform.position = playerTransform.position + offset;
    }
}
