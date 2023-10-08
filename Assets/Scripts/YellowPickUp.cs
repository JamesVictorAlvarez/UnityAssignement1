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
            touched = true;
            YellowParticle.Play();
            GameManager.instance.IncreseScore();
            Destroy(gameObject, YellowParticle.main.duration);
        }
    }
}
