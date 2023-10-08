using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpHover : MonoBehaviour
{
    Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate the pick ups
        transform.Rotate(Vector3.up * 50 * Time.deltaTime, Space.Self);

        // Use the sin function to make the pick ups go up and down
        float newY = Mathf.Sin(Time.time * 3.5f) * 0.3f + pos.y;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
