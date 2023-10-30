using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBloodParticle : MonoBehaviour
{
    ParticleSystem bloodVFX;
    void Start()
    {
        bloodVFX = GetComponentInChildren<ParticleSystem>();
        GetComponent<Health>().OnDied+= PlayParticle;
    }

    private void PlayParticle()
    {
        bloodVFX.Play();
    }
}
