using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    public Transform characterBody;
    public Transform characterHead;


    float sensitivtyX = 0.5f;
    float sensitivtyY = 0.5f;

    float rotationX = 0;
    float rotationY = 0;

    float angleYmin = -40;
    float angleYmax = 70;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    private void LateUpdate() {
        transform.position = characterHead.position;
    }

    void Update() {

        float verticalDelta = Input.GetAxisRaw("Mouse Y") * sensitivtyY;
        float horizontalDelta = Input.GetAxisRaw("Mouse X") * sensitivtyX;


        rotationX += horizontalDelta;
        rotationY += verticalDelta;

        rotationY = Mathf.Clamp(rotationY, angleYmin, angleYmax);

        characterBody.localEulerAngles = new Vector3 (0, rotationX, 0);
    
        transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
    }
}
