using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    [Header("General Setup Settings")]
    [Tooltip("How fast ship moves up and down")] 
    [SerializeField] float controlSpeedX = 3.2f;
    [SerializeField] float controlSpeedY = 8.2f;
    [Tooltip("Limit of how much can an object move on X(LEFT,RIGHT)")] 
    [SerializeField] float xRange = 5f;
    [Tooltip("Limit of how much can an object move on Y+(UP)")] 
    [SerializeField] float yRange = 4.2f;
    [Tooltip("Limit of how much can an object move on Y-(DOWN)")] 
    [SerializeField] float yRangeNeg = 1f;

    [Header("Particle emittor")]
    public GameObject[] lasers;

    [Header("Key bindings")]
    [SerializeField] InputAction movement;
    [SerializeField] InputAction fire;
    

    void Update()
    {
        ProcessTranslation();
        ProcessFiring();
        
    }

    void OnEnable() {
        movement.Enable();
        fire.Enable();
        
    }
    void OnDisable() {
        movement.Disable();
        fire.Disable();
    }

    private void ProcessTranslation()
    {
        float xThrow = movement.ReadValue<Vector2>().x;
        float yThrow = movement.ReadValue<Vector2>().y;
 
        float xOffset = xThrow * Time.deltaTime * controlSpeedX;
        float rawPosX = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawPosX, -xRange, xRange);

        float yOffset = yThrow * Time.deltaTime * controlSpeedY;
        float rawPosY = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawPosY, -yRangeNeg, yRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }

    void ProcessFiring()
    {
        float fireTrue = fire.ReadValue<float>();
        if (fireTrue > 0)
        {
            DoLasers(true);
        }
        else
        {
            DoLasers(false);
        }
    }

    void DoLasers(bool fireBool)
    {
        foreach (GameObject laser in lasers)
        {
            var emissionModule = laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = fireBool;
        }
    }
}
