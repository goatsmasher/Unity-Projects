using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            var xu = Input.GetAxis("Horizontal") * Time.deltaTime * 700.0f;
            var zu = Input.GetAxis("Vertical") * Time.deltaTime * 100.0f;
			// print(Input.Get);
			print(Input.GetAxis("Vertical"));

            transform.Rotate(0, xu, 0);
            transform.Translate(0, 0, zu);
        }
        else
        {

            var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
            var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

            transform.Rotate(0, x, 0);
            transform.Translate(0, 0, z);
        }
    }
}