using UnityEngine;
using System.Collections;

public class RTSCameraScript : MonoBehaviour {

//    private int scrollDistance = 5;
    private float scrollSpeed = 30;

    void Update ()
    {
        float mousePosX = Input.mousePosition.x;
        float mousePosY = Input.mousePosition.y;

        //mousePosX < scrollDistance 
        if ( Input.GetKey(KeyCode.A))
        {
            moveThisCamera(Vector3.right, -scrollSpeed);
        }

        //mousePosX >= Screen.width - scrollDistance || 
        if (Input.GetKey(KeyCode.D))
        {
            moveThisCamera(Vector3.right, scrollSpeed);
        }

        //mousePosY < scrollDistance || 
        if (Input.GetKey(KeyCode.S))
        {
            moveThisCamera(Vector3.up, -scrollSpeed);
        }

        //mousePosY >= Screen.height - scrollDistance || 
        if (Input.GetKey(KeyCode.W) )
        {
            moveThisCamera(Vector3.up, scrollSpeed);
        }
    }

    private void moveThisCamera( Vector3 direction, float scrollSpeed)
    {
        GetComponent<Transform>().Translate(direction * scrollSpeed * Time.deltaTime);
    }

}
