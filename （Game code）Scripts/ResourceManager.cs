using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager instance;
    private void Awake()
    {
        instance = this;
    }
    public AudioClip LoadAudioClip(string name) {
        Debug.Log(Resources.Load<AudioClip>(name).name);
      return   Resources.Load<AudioClip>(name);
    
    }
}
