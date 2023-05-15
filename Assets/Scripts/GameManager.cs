using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.PostProcessing;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    public Animator cameraAnimator;
    public Animator textAnimator;
    public PostProcessVolume PP;
    private DepthOfField dof;

    public GameObject enterButton;

    // Start is called before the first frame update
    void Start()
    {
        if (gameManager == null)
        {
            DontDestroyOnLoad(gameObject);
            gameManager = this;
        }

        else if (gameManager != this)
        {
            Destroy(gameObject);
        }

        PP.profile.TryGetSettings(out dof);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveObjects(GameObject obj)
    {
        obj.transform.Translate(new Vector3(-3, 0, 0));
    }

    public void ButtonOff(GameObject button)
    {
        button.SetActive(false);
    }

    public void EnterGame()
    {
        textAnimator.SetTrigger("PressEnter");
        cameraAnimator.SetTrigger("EnterGame");
        StartCoroutine(LoadLevel(1));
        //ButtonOff(enterButton);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public IEnumerator LoadLevel(int levelNum)
    {
        yield return new WaitForSeconds(3.5f);
        SceneManager.LoadScene(levelNum);
    }
}
