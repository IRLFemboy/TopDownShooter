using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfLevelSwapScene : MonoBehaviour
{
    [SerializeField]
    public string nextLevelName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("End of Level"))
        {
            Invoke("SwapScene", 1);
        }
    }

    void SwapScene()
    {
        SceneManager.LoadScene(nextLevelName);
    }
}
