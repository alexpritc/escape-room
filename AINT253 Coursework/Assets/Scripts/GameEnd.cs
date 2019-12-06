using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnd : MonoBehaviour
{
    public string sceneName;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Game End")
        {
            PlayerCollisions.allPuzzlesComplete = false;
            PlayerCollisions.fuseboxPuzzleComplete = true;
            KeypadManager.isKeypadPuzzleComplete = false;

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            SceneManager.LoadScene(sceneName);
        }
    }
}
