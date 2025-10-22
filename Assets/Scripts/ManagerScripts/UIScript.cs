using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{
    public enum statusChoice { stop, play, paused };
    private statusChoice status;
    [SerializeField] private List<bool> isOnRightPlace = new() { false, false };
    [SerializeField] private GameObject CongratulationsPopUp;
    [SerializeField] private GameObject WrongPopUp;

    void Start()
    {
        status = statusChoice.stop;
    }

    public void Play()
    {
        status = statusChoice.play;
    }

    public void Pause()
    {
        status = statusChoice.paused;
    }

    public void Stop()
    {
        status = statusChoice.stop;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public statusChoice GetStatus()
    {
        return status;
    }

    public void SetIsOnRightPlace(int position, bool isOnRightPlace)
    {
       this.isOnRightPlace[position] = isOnRightPlace;
       
    }

    public void InGameChecker()
    {
        if (isOnRightPlace.Contains(false))
        {
            isOnRightPlace.ForEach(x => x = false);
            Debug.Log("Wrong");
            WrongPopUp.SetActive(true);

            Invoke("WrongPopUpActiveFalse", 5);

        }
        else
        {
            Debug.Log("Correct");
            CongratulationsPopUp.SetActive(true);
        }
    }
    
    private void WrongPopUpActiveFalse()
    {
        WrongPopUp.SetActive(false);
    }
}
