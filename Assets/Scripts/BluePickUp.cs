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
            GameManager.instance.DoubleJumpChangeStatus();
            Invoke("Active", 3.0f);
            Invoke("Respawn", 30.0f);
            Invoke("ChangeDoubleJump", 15.0f);
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

    // When you pick up a blue power up you only have 15 seconds to use it.
    private void ChangeDoubleJump()
    {
        if (GameManager.instance.GetDoubleJump() == true)
        {
            Debug.Log("time's up");
            GameManager.instance.DoubleJumpChangeStatus();
        }
    }
}
