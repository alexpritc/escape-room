using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeypadManager : MonoBehaviour
{
    public static string code = "1998";
    public static string playerInput;

    public static bool isKeypadPuzzleComplete = false;

    public static Animator keypadAnim;

    // Start is called before the first frame update
    void Start()
    {
        isKeypadPuzzleComplete = false;

        playerInput = "";

        keypadAnim = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if (playerInput.Length == 4)
        {
            isKeypadPuzzleComplete = TestCode();

            if (isKeypadPuzzleComplete == true)
            {
                TurnLightsGreen();
            }
            else
            {
                FlashLightsRed();
                ClearCode();
            }
        }
    }

    public static void AddToCode(string character)
    {
        playerInput += character;
        Debug.Log("Send " + playerInput);
    }

    // Is the inputted number the same as the code.
    public static bool TestCode()
    {
        bool isCorrect = false;

        if (playerInput == code)
        {
            isCorrect = true;
        }

        return isCorrect;
    }

    public static void ClearCode()
    {
        playerInput = "";
    }

    public static void FlashLightsRed()
    {
        keypadAnim.SetBool("isWrong", true);
    }

    public static void TurnLightsGreen()
    {
        keypadAnim.SetBool("isWrong", false);
        keypadAnim.SetBool("isRight", true);

        isKeypadPuzzleComplete = true;
    }
}
