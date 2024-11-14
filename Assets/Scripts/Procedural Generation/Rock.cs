using System;
using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class Rock : MonoBehaviour
{
    [SerializeField] float shakeModifier = 10f;
    [SerializeField] ParticleSystem collisonParticleSystem;
    [SerializeField] AudioSource audioSource;
    [SerializeField] float collisionCoolDown = 1f;
    CinemachineImpulseSource cinemachineImpulseSource;

    float collisionTimer = 1f;
    void Awake(){
        cinemachineImpulseSource = GetComponent<CinemachineImpulseSource>();
    }
    void Update(){
        collisionTimer += Time.deltaTime;
    }
    void OnCollisionEnter(Collision other)
    {
        if(collisionTimer < collisionCoolDown) return;
        FireImpulse();
        CollisionFX(other);
        collisionTimer = 0f;
    }

    private void FireImpulse()
    {
        float distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        float shakeIntensity = (1f / distance) * shakeModifier;
        shakeIntensity = MathF.Min(shakeIntensity, 1f);
        cinemachineImpulseSource.GenerateImpulse(shakeIntensity);
    }
    void CollisionFX(Collision other){
            ContactPoint contactPoint = other.contacts[0];
            collisonParticleSystem.transform.position = contactPoint.point;
            collisonParticleSystem.Play();
            audioSource.Play();
    }
}
