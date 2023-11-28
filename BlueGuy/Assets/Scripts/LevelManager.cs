using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{

    int LevelUnlocked;
    [SerializeField] private Button[] LevelBtns;


    // Start is called before the first frame update
    void Start()
    {
        LevelUnlocked = PlayerPrefs.GetInt("LevelUnloked", 1);

        for (int i = 0; i < LevelBtns.Length; i++)
        {
            LevelBtns[i].interactable = false;
        }

        for (int i = 0; i < LevelUnlocked; i++)
        {
            LevelBtns[i].interactable = true;
        }
    }


    public void LoadLevel(int LevelIndex)
    {
        SceneManager.LoadScene(LevelIndex);
        Time.timeScale = 1f;
    }

   
}
