using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;
using UnityEngine.Audio;
using Unity.VisualScripting;
public class settings : MonoBehaviour
{
    
    [SerializeField]
    private Canvas main, Settings, noisecanvas, video, controles;
    [SerializeField]
    private AudioMixer mixer;
    [SerializeField]


    // change screens
    public void change1()
    {
        main.gameObject.SetActive(false);
        Settings.gameObject.SetActive(true);
    }
    public void back1()
    {
        main.gameObject.SetActive(true);
        Settings.gameObject.SetActive(false);
    }
    public void chang2()
    {
        Settings.gameObject.SetActive(false);
        noisecanvas.gameObject.SetActive(true);
    }
    public void back2()
    {
        noisecanvas.gameObject.SetActive(false);
        Settings.gameObject.SetActive(true);
    }
    public void chang3()
    {
        Settings.gameObject.SetActive(false);
        video.gameObject.SetActive(true);
    }
    public void back3()
    {
        video.gameObject.SetActive(false);
        Settings.gameObject.SetActive(true);
    }
    public void change4()
    {
        Settings.gameObject.SetActive(false);
        controles.gameObject.SetActive(true);
    }
    public void back4()
    {
        Settings.gameObject.SetActive(true);
        controles.gameObject.SetActive(false);
    }
    //change video settings
    public void changevideo(int settingLevel)
    {
        QualitySettings.SetQualityLevel(settingLevel);
        PlayerPrefs.SetFloat("video", settingLevel);
        PlayerPrefs.Save();
    }
    //change audio settings
    public void Audio(float volume)
    {
        mixer.SetFloat("music", volume);
        PlayerPrefs.SetFloat("music", volume);
        PlayerPrefs.Save();
    }
    public void buttonaudio(float booton)
    {
        mixer.SetFloat("vfx", booton);
        PlayerPrefs.SetFloat("vfx", booton);
        PlayerPrefs.Save();
    }
    public void masteraudio(float master)
    {
        mixer.SetFloat("master", master);
        PlayerPrefs.SetFloat("master", master);
        PlayerPrefs.Save();
    }
    private void Start()
        //audio on buttons/background audio
    {
        if (PlayerPrefs.HasKey("music"))
        {
            mixer.SetFloat("music", PlayerPrefs.GetFloat("music"));
        }
        if (PlayerPrefs.HasKey("vfx"))
        {
            mixer.SetFloat("vfx", PlayerPrefs.GetFloat("vfx"));
        }
        if (PlayerPrefs.HasKey("master"))
        {
            mixer.SetFloat("master", PlayerPrefs.GetFloat("master"));
        }
        if (PlayerPrefs.HasKey("video"))
        {
            mixer.SetFloat("video", PlayerPrefs.GetFloat("video"));
        }
    }
    //exit
    public void Exit()
    {
        Application.Quit();
    }

}

