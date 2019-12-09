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
            FuseBox.fuseboxPuzzleComplete = false;
            KeypadManager.isKeypadPuzzleComplete = false;

            FuseBox.switch1 = false;
            FuseBox.switch2 = false;
            FuseBox.switch3 = false;
            FuseBox.switch4 = false;

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            SceneManager.LoadScene(sceneName);
        }
    }
}
