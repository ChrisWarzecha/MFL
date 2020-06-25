using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformObject : MonoBehaviour
{
    [CC("[string name][bool isLocal][string direction][float distance] Move an object in direction of distance in local or world space.")]
    public static void MoveDirection(string name, bool isLocal, string direction, float distance)
    {
        GameObject movingObject = GameObject.Find(name);
        if (movingObject != null)
        {
            Vector3 movingDir = Vector3.zero;
            if (direction == "up")
            {
                movingDir = Vector3.up;
            }
            else if (direction == "down")
            {
                movingDir = Vector3.down;
            }
            else if (direction == "forward")
            {
                movingDir = Vector3.forward;
            }
            else if (direction == "back")
            {
                movingDir = Vector3.back;
            }
            else if (direction == "left")
            {
                movingDir = Vector3.left;
            }
            else if (direction == "right")
            {
                movingDir = Vector3.right;
            }
            else
            {
                Debug.Log("Couldn't find direction " + direction);
                return;
            }

            movingDir *= distance;
            
            switch (isLocal)
            {
                case true:
                    movingObject.transform.localPosition += movingDir;
                    break;
                default:
                    movingObject.transform.position += movingDir;
                    break;
            }
        }
        else
        {
            Debug.Log("Couldn't find object of name " +name);
        }
    }

    [CC("[string name][bool isLocal][Vector3 movingDir] Move an object in movingDir in local or world space.")]
    public static void Move(string name, bool isLocal, Vector3 movingDir)
    {
        GameObject movingObject = GameObject.Find(name);
        if (movingObject != null)
        {
            switch (isLocal)
            {
                case true:
                    movingObject.transform.localPosition += movingDir;
                    break;
                default:
                    movingObject.transform.position += movingDir;
                    break;
            }
        }
        else
        {
            Debug.Log("Couldn't find object of name " + name);
        }
    }
}
