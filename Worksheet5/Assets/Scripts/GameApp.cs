using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PGGE.Patterns;
using UnityEngine.SceneManagement;

public class GameApp : Singleton<GameApp>
{
    // Start is called before the first frame update
    void Start()
    {
        mPause = false;
        SceneManager.LoadScene("Menu");

    }

    public bool mPause = false;

    public void PauseGame(bool flag)
    {
        mPause = flag;
        if (mPause)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    /*public bool GamePaused
    {
        get { return mPause; }
        set
        {
            mPause = value;
            mOnPause?.Invoke(GamePaused);
            if (GamePaused)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
        }
    }*/

  // Update is called once per frame
  void Update()
  {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame(!mPause);
        }
    }
}
