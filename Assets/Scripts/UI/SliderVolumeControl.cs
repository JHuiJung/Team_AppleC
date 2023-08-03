using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DarkTonic.MasterAudio;

public class SliderVolumeControl : MonoBehaviour
{
    public string busName;

    public void SetVolume(float volume)
    {
        MasterAudio.SetBusVolumeByName(busName, volume);
    }
    
}
