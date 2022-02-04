using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lobby : MonoBehaviour
{
    [SerializeField]
    InputField Inputname;
    [SerializeField]
    Button JoinRoomButton;
    [SerializeField]
    Text connectionStatus;

    private string mPlayername;

    // Start is called before the first frame update
    void Start()
    {
        JoinRoomButton.onClick.AddListener(delegate
        {
            OnClickJoinRoom();
        });
    }

    public void OnClickJoinRoom()
    {
        connectionStatus.gameObject.SetActive(true);

        mPlayername = Inputname.text;
        Debug.Log("Welcome " + mPlayername);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
