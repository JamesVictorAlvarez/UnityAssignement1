using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePickUp : MonoBehaviour
{
    public ParticleSystem BlueParticle;
    bool touched = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && touched == false)
        {
            touched = true;
            BlueParticle.Play();
            Invoke("Active", 3.0f);
            Invoke("Respawn", 8.0f);
        }
    }

    private void Active()
    {
        gameObject.SetActive(false);
    }

    private void Respawn()
    {
        touched = false;
        gameObject.SetActive(true);
    }
}
