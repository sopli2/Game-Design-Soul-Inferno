using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public Transform respawnPoint;
    public GameObject playerPrefab;

    public void LoadLevel(string level)
    {
        Debug.Log("Attempting to load " + level);
        SceneManager.LoadScene(level);
    }
    public void QuitGame()
    {
        Debug.Log("Attempting to quit... ");
        Application.Quit();
    }

    private void Awake()
    {
        instance = this;
    }

    public void Respawn()
    {
        Instantiate(playerPrefab, respawnPoint.position, Quaternion.identity);
    }
}
