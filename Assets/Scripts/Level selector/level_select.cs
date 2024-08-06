using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level_select : MonoBehaviour
{
   public void Onlevel1b ()
    {
        SceneManager.LoadScene ("Level_1");
    }

    public void Onlevel2b ()
    {
        SceneManager.LoadScene ("Level_2");
    }

    public void Onlevel3b ()
    {
        SceneManager.LoadScene ("Level_3");
    }

    public void Onlevel4b ()
    {
        SceneManager.LoadScene ("Level_4");
    }

//    public void Onlvl5Button ()
//    {
//        SceneManager.LoadScene ("Level_5");
//    }

    public void Onbackb ()
    {
        SceneManager.LoadScene ("MainMenu");
    }
}

