using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePickUp : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("hit");
            gameObject.SetActive(false);
            Invoke("Respawn", 3.0f);
        }
    }

    private void Respawn()
    {
        gameObject.SetActive(true);
    }
}
