using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField]
    Button ButtonSinglePlayer;
    [SerializeField]
    Button ButtonMultiPlayer;

    public void Start()
    {
        ButtonSinglePlayer.onClick.AddListener(delegate(){
            onClick_Singleplayer();
        });

        ButtonMultiPlayer.onClick.AddListener(delegate(){
            onClick_Multiplayer();
        });
    }

    public void onClick_Singleplayer()
    {
        Debug.Log("loading SinglePlayer");
        SceneManager.LoadScene("Singleplayer");
    }

    public void onClick_Multiplayer()
    {
        Debug.Log("loading Multiplayer");
        SceneManager.LoadScene("MultiplayerLauncher");
    }
}
