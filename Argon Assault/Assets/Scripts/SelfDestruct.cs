using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    public float timeDestroy = 3f;
    void Start() {
        Destroy(this.gameObject, timeDestroy);
    }
}
