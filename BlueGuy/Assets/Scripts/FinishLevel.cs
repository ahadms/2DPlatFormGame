using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
{
    private AudioSource finishSoundEffect;

    private bool LevelCompleted = false;

    [SerializeField] private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        finishSoundEffect = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player" && !LevelCompleted)
        {
            finishSoundEffect.Play();
            LevelCompleted = true;
            rb.bodyType = RigidbodyType2D.Static;
            PassLevel();
            Invoke("CompleteLevel", 1f);

        }
    }

    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        HealthManager.PlayerHealth = 3;
    }


    private void PassLevel()
    {
        int CurrentLevel = SceneManager.GetActiveScene().buildIndex;

        if (CurrentLevel >= PlayerPrefs.GetInt("LevelUnlocked"))
        {

            PlayerPrefs.SetInt("LevelUnloked", CurrentLevel + 1);
        }
    }
}
