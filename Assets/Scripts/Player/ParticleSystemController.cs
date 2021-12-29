using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemController : MonoBehaviour
{
    private ColliderController colliderController;
    private ParticleSystem particleSystem;
    private SoapStats soapStats;
    // Start is called before the first frame update
    void Start()
    {
        soapStats = GetComponent<SoapStats>();
        colliderController = GetComponent<ColliderController>();
        particleSystem = GetComponent<ParticleSystem>();
        particleSystem.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (soapStats.wet)
        {
            particleSystem.Play();
        }
        else if(!soapStats.wet && particleSystem.isPlaying)
        {
            Invoke("StopParticleSystem", particleSystem.main.duration);
        }
    }

    private void StopParticleSystem()
    {
        particleSystem.Stop();
    }
}
