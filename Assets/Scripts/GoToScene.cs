using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToScene : MonoBehaviour
{
    [SerializeField]
    string goToNameScene;

    public void GoToTheScene()
    {
        SceneManager.LoadScene(goToNameScene);
    }
}
