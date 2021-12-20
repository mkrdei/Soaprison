using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemController : MonoBehaviour
{
    private PlayerColliderCheck playerScaling;
    private ParticleSystem particleSystem;
    // Start is called before the first frame update
    void Start()
    {
        playerScaling = GetComponent<PlayerColliderCheck>();
        particleSystem = GetComponent<ParticleSystem>();
        particleSystem.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerScaling.wet)
        {
            particleSystem.Play();
        }
        else if(!playerScaling.wet && particleSystem.isPlaying)
        {
            Invoke("StopParticleSystem", particleSystem.main.duration);
        }
    }

    private void StopParticleSystem()
    {
        particleSystem.Stop();
    }
}
