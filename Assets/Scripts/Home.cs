using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Home : MonoBehaviour
{
   public void OnPlayButton ()
    {
        SceneManager.LoadScene ("SampleScene");
    }

    public void OnShopButton ()
    {
        SceneManager.LoadScene ("Store");
    }

//    public void OnStagesButton ()
//    {
//      SceneManager.LoadScene ("Level Select");
//    }
}

