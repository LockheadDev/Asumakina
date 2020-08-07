using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
   public AudioMixer AudioMix;
   public Dropdown resolutionDropdown;
   public Dropdown qualityDropdown;
   public Toggle fullScreenToggle;

   public Slider volMaster;
   public Slider volFX;
   public Slider volMusic;

   private Resolution[] resolutions;

   private int screenInt ;
   private bool isFS = false;
   

   const string prefName = "optionvalue";
   const string resName = "resolutionoption";

   void Awake()
   {
      screenInt = PlayerPrefs.GetInt("fstogglestate",1);
      if(screenInt==1)
      {
         isFS = true;
         fullScreenToggle.isOn = true;

      }
      else
      {
         fullScreenToggle.isOn = false;

      }
      resolutionDropdown.onValueChanged.AddListener(new UnityEngine.Events.UnityAction<int>(index=>
      {
         PlayerPrefs.SetInt(resName,resolutionDropdown.value);
         PlayerPrefs.Save();
      }));

      qualityDropdown.onValueChanged.AddListener(new UnityEngine.Events.UnityAction<int>(index=>
      {
         PlayerPrefs.SetInt(prefName,qualityDropdown.value);
         PlayerPrefs.Save();
      }));
      Start();
   }

    public void Refresh()
   {
      Awake();
      Start();

   }

   void Start()
   {
      
      volMaster.value = PlayerPrefs.GetFloat("MasterVolume",1f);
      volFX.value = PlayerPrefs.GetFloat("FXVolume",1f);
      volMusic.value = PlayerPrefs.GetFloat("MusicVolume",1f);
      AudioMix.SetFloat("master", PlayerPrefs.GetFloat("MasterVolume"));
      AudioMix.SetFloat("FX", PlayerPrefs.GetFloat("FXVolume"));
      AudioMix.SetFloat("music", PlayerPrefs.GetFloat("MusicVolume"));

      qualityDropdown.value = PlayerPrefs.GetInt(prefName,3);


      resolutions =Screen.resolutions;
      resolutionDropdown.ClearOptions();
      List<string> options = new List<string>();
      int currentResolutionIndex = 0;
      
      for (int i = 0; i < resolutions.Length; i++)
      {
         string option = resolutions[i].width + " x " + resolutions[i].height;
         options.Add(option);
         if (resolutions[i].width == Screen.currentResolution.width &&
             resolutions[i].height == Screen.currentResolution.height)
         {
            currentResolutionIndex = i;
         }
      }
      resolutionDropdown.AddOptions(options);
      resolutionDropdown.value = PlayerPrefs.GetInt(resName,currentResolutionIndex);
      resolutionDropdown.RefreshShownValue();
   }
   

   public void setVolumeFX(float vol)
   {
      AudioMix.SetFloat("FX",vol);
      PlayerPrefs.SetFloat("FXVolume",vol);
      PlayerPrefs.Save();
   }


   public void setVolumeMusic(float vol)
   {
      AudioMix.SetFloat("music",vol);
      PlayerPrefs.SetFloat("MusicVolume",vol);
      PlayerPrefs.Save();
   }
   

   public void setVolumeMaster(float vol)
   {
      AudioMix.SetFloat("master",vol);
      PlayerPrefs.SetFloat("MasterVolume",vol);
      PlayerPrefs.Save();
   }


   public void setQuality(int qualityIndex)
   {
      QualitySettings.SetQualityLevel(qualityIndex);
      PlayerPrefs.Save();
   }


   public void setFullScreen(bool isFullScreen)
   {
      Screen.fullScreen = isFullScreen;
      if(isFullScreen)
      {
         PlayerPrefs.SetInt("fstogglestate",1);
         PlayerPrefs.Save();
         isFS =true;
      }
      else
      {

         PlayerPrefs.SetInt("fstogglestate",0);
         PlayerPrefs.Save();
      }
      
   }


   public void setResolution(int resolutionIndex)
   {
      Resolution resolution = resolutions[resolutionIndex];
      Screen.SetResolution(resolution.width,resolution.height,Screen.fullScreen);
      PlayerPrefs.Save();
   }
}
