using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndSeq : MonoBehaviour
{
    private bool touching = false;
    public Animator animator;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Fade();
        }
    }

    public void Fade()
    {
        animator.SetTrigger("Fade");
    }

    public void onFadeComp()
    {
        SceneManager.LoadScene("End1");
    }


}
