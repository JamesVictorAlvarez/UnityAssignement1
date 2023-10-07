using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowPickUp : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("hit");
            gameObject.SetActive(false);
        }
    }
}
