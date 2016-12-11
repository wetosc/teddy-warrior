using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class CharacterObject : MonoBehaviour
{
    public float speed = 0.05f;

    void Start()
    {

    }

    void Update()
    {
        List<bool> keys = new List<bool> {
            Input.GetKey (KeyCode.UpArrow),
            Input.GetKey (KeyCode.RightArrow),
            Input.GetKey (KeyCode.DownArrow),
            Input.GetKey (KeyCode.LeftArrow)
        };
        move(keys);
    }


    void move(List<bool> directions)
    {
        Vector3 movement = new Vector3();
        movement.x -= (directions[1] ? 0 : 1) * speed;
        movement.x += (directions[3] ? 0 : 1) * speed;
        movement.y -= (directions[0] ? 0 : 1) * speed;
        movement.y += (directions[2] ? 0 : 1) * speed;

        if (movement != Vector3.zero)
        {
            float zAngle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg;
            Debug.Log(zAngle);
            transform.eulerAngles = new Vector3(0, 0, zAngle);
        }
        transform.Translate(movement, relativeTo: Space.World);
    }

}
