using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEditor.SearchService;
using UnityEngine.SceneManagement;

public class LvlExit : MonoBehaviour
{
    [SerializeField] float lvlLoadDelay = 2f;
    
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            StartCoroutine(loadNextLevel());
        }
    }
    IEnumerator loadNextLevel()
    {
        yield return new WaitForSecondsRealtime(lvlLoadDelay);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nexSceneIndex = currentSceneIndex + 1;
        if(nexSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nexSceneIndex = 0;
        }
        FindObjectOfType<ScreenPersist>().ScreenDestroy();
        SceneManager.LoadScene(nexSceneIndex);
    }
    
   
   
}
