using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Button back;

    public void OnBackButton()
    {
        SceneManager.LoadScene(0);
    }

    // Start is called before the first frame update
    void Start()
    {
        back.onClick.AddListener(OnBackButton);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
