using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfLevelSwapScene : MonoBehaviour
{
    [SerializeField]
    public string nextLevelName;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("End of Level"))
        {
            Debug.Log("Hit the end goal!");
            Invoke("SwapScene", 1);
        }
        else
        {
            Debug.Log("Didn't detect the end goal");
        }
    }

    void SwapScene()
    {
        SceneManager.LoadScene(nextLevelName);
    }
}
