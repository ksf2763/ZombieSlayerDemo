using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSettings : MonoBehaviour
{

    FMOD.Studio.Bus Master;
    FMOD.Studio.Bus Global;
    float masterVolume;
    bool pause = false;
    [SerializeField] UnityEngine.UI.Slider slider;

    public float MasterVolume
    {
        get => masterVolume;
        set => masterVolume = value;
    }

    public bool Pause
    {
        get => pause;
        set => pause = value;
    }

    // Start is called before the first frame update
    void Start()
    {
        Master = FMODUnity.RuntimeManager.GetBus("bus:/Master");
        Global = FMODUnity.RuntimeManager.GetBus("bus:/");
        Global.getVolume(out masterVolume);
        if(slider == null)
        {
            if(GetComponentInChildren<UnityEngine.UI.Slider>())
                slider = GetComponentInChildren<UnityEngine.UI.Slider>();
        }
        if(slider)
            slider.value = masterVolume;
    }

    // Update is called once per frame
    void Update()
    {
        Global.setVolume(masterVolume);

        if(slider)
            slider.value = masterVolume;

        if (Time.timeScale == 0f)
            pause = true;
        else
            pause = false;
        Master.setPaused(pause);
    }

    public void OnHoverUI()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Menu Hover");
    }

    public void OnClickUI()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Menu Click");
    }
}
