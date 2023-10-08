using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowPickUp : MonoBehaviour
{
    public ParticleSystem YellowParticle;
    bool touched = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && touched == false)
        {
            Debug.Log("asdas");
            touched = true;
            YellowParticle.Play();
            Destroy(gameObject, YellowParticle.main.duration);
        }
    }
}
