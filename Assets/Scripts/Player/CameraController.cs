using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] float minFOV = 35f;
    [SerializeField] float maxFOV = 85f;
    [SerializeField] float zoomDuration = 1f;
    [SerializeField] float zoomSpeedModifier = 5f;
    [SerializeField] ParticleSystem speedUpParticleSystem;
    CinemachineCamera cinemachineCamera;
    void Awake(){
        cinemachineCamera = GetComponent<CinemachineCamera>();
    }
    public void ChangeCameraFOV(float speedAmount){
        StopAllCoroutines();
        StartCoroutine(ChangeFOVRoutine(speedAmount));
        if(speedAmount > 0){
            speedUpParticleSystem.Play();
        }
    }
    IEnumerator ChangeFOVRoutine(float speedAmount){

        float startFOV = cinemachineCamera.Lens.FieldOfView;
        float targetFOV= Mathf.Clamp(startFOV + speedAmount * zoomSpeedModifier,minFOV,maxFOV);
        float elapsedTime = 0f;
        while(elapsedTime < zoomDuration){
            float t = elapsedTime/zoomDuration;
            elapsedTime+=Time.deltaTime;
            cinemachineCamera.Lens.FieldOfView = Mathf.Lerp(startFOV,targetFOV,t);
            yield return null;
        }
        cinemachineCamera.Lens.FieldOfView = targetFOV;
    }
}
