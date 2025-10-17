using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionManager : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Reset"))
        {
            // If the player collides with an object that has the tag "Reset" then reload the scene from the begining
            SceneManager.LoadScene(0);

        }
    }
}
