using UnityEngine;
using System.Collections;

public class RotationScript : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(Vector3.left* Time.deltaTime * 20f, Space.World);
    }
}
