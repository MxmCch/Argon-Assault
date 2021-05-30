using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    public ParticleSystem explosionParticle;
    public bool isTransitioning = false;
    public GameObject[] shipParts;

    void OnCollisionEnter(Collision other)
    {
        if (isTransitioning)
        {
            return;
        }
        StartCrashSequence(other);
        HideShip();
    }

    private void HideShip()
    {
        foreach (GameObject item in shipParts)
        {
            item.GetComponent<MeshRenderer>().enabled = false;   
        }
    }

    private void StartCrashSequence(Collision other)
    {
        explosionParticle.Play();
        GetComponent<PlayerControls>().enabled = false;
        isTransitioning = true;
        Invoke("ReloadLevel", 1);
    }

    void ReloadLevel()
    {
        int currenctSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currenctSceneIndex);
    }

    void OnTriggerEnter(Collider other) {
        Debug.Log("you just triggered" + other.gameObject.name);    
    }
}
