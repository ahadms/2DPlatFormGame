using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    [SerializeField] private AudioSource trapSoundEffect;

    [SerializeField] GameObject GameOverPanel;
    // used this for when player collid with trap only 1 collition happening if player not moved not getting damages
    // [SerializeField]PlayerMovement playerScript;

    [SerializeField] AudioSource DeathSoundEffect;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
       // playerScript = GetComponent<PlayerMovement>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap")){
            rb.velocity = new Vector2(rb.velocity.x, 14f);
            trapSoundEffect.Play();

            //  playerScript.Jump();
            // Die();
            // Invoke("RestartLevel", 1f);
            HealthManager.PlayerHealth--;
            anim.SetLayerWeight(1, 1);
            StartCoroutine(AnimlayerBackToZero());
            if (HealthManager.PlayerHealth <= 0) {

                
                Die();
                Invoke("gameOverPanelShow", 1f);

                //Time.timeScale = 0f;  
            }
        }
    }

    IEnumerator AnimlayerBackToZero()
    {
        yield return new WaitForSeconds(2);
        anim.SetLayerWeight(1, 0);
    }

    private void Die()
    {
        DeathSoundEffect.Play();
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
        
    }

    private void gameOverPanelShow()
    {
         GameOverPanel.SetActive(true);
    }


   
}
