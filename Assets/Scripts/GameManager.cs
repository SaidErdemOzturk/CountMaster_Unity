using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerManager player;
    [SerializeField] private CanvasManager canvasManager;
    private float tempSpeed;

    private void Start()
    {
        tempSpeed = player.speed;
        player.speed = 0;

    }
    public void StartGame()
    {
        player.speed = tempSpeed;
        canvasManager.StartGameTextChange();
    }

    public void FinishGame()
    {
        player.speed = 0;
        canvasManager.NextGameTextChange();

    }

    public void NextGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
