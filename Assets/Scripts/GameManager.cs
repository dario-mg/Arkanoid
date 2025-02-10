using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private int totalBlocks;
    public GameObject ball;
    private string nextSceneName = "nivel2";
    private string gameOver = "GameOver";
    [SerializeField] private Button botonQuit; // Referencia al botón de salida


    void Start()
    {
        // Encuentra todos los bloques en la escena al inicio del juego
        totalBlocks = FindObjectsByType<Block>(FindObjectsSortMode.None).Length;
        Debug.Log("Bloques: " + totalBlocks);
    }

    private void Awake()
    {
        Debug.Log("QUIT!");
        botonQuit.onClick.AddListener(() => { Application.Quit(); });
    }


    // Update is called once per frame
    void Update()
    {
        if (ball.transform.position.y < -110)
        {
            ShowGameOver();
        }

    }

    private void ShowGameOver()
    {
        SceneManager.LoadScene(gameOver, LoadSceneMode.Single);
    }

    public void BlockHidden()
    {
        totalBlocks--;
        if (totalBlocks <= 0)
        {
            LoadNextScene();
        }
    }


    public void LoadNextScene()
    {
        Debug.Log("Cargando siguiente escena");
        SceneManager.LoadScene(nextSceneName, LoadSceneMode.Single);
    }

}
