using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject deathVFX;
    public GameObject hitVFX;
    public int scoreForKill = 10;
    public int healthPoints = 5;
    public int damage = 1;

    ScoreBoard scoreBoard;
    GameObject parentGameObject;

    void Start() {
        scoreBoard = FindObjectOfType<ScoreBoard>();
        parentGameObject = GameObject.FindWithTag("SpawnAtRuntime");
    }

    void OnParticleCollision(GameObject other)
    {
        healthPoints -= damage;
        if (healthPoints <= 0)
        {
            TriggerDeath();
        }
        else
        {
            EnemyHit();
        }

    }

    private void TriggerDeath()
    {
        GameObject vfx = Instantiate(deathVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parentGameObject.transform;
        scoreBoard.IncreaseScore(scoreForKill);
        Destroy(this.gameObject);
    }

    private void EnemyHit()
    {
        GameObject vfx = Instantiate(hitVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parentGameObject.transform;
    }
}
