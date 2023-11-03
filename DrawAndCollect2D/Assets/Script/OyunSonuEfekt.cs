using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OyunSonuEfekt : MonoBehaviour
{
    private void OnParticleSystemStopped()
    {
        Time.timeScale = 0;
    }
}
