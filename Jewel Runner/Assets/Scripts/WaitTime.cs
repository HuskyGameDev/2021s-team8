using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaitTime : MonoBehaviour
{
    private float delay = 3f;
    private float timeElapsed;
    public Animator animator;
    public string sceneName;

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        if(timeElapsed > delay)
        {
            Fade();
        }
    }

    public void Fade()
    {
        animator.SetTrigger("FadeOut");
    }

    public void onFadeComp()
    {
        SceneManager.LoadScene(sceneName);
    }
}
