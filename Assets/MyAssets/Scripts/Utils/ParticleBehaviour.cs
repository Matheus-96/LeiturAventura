using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ParticleBehaviour : MonoBehaviour
{
    private ParticleSystem _system;
    // Start is called before the first frame update
    void Start()
    {
        _system = GetComponent<ParticleSystem>();
        _system.Play();
        Destroy(gameObject, 4f);
    }

}
