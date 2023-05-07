using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{

    [SerializeField] private Button startGameButton;
    [SerializeField] private Button nextGameButton;
    public void StartGameTextChange()
    {
        startGameButton.enabled = false;
        startGameButton.gameObject.SetActive(false);
    }

    public void NextGameTextChange()
    {
        nextGameButton.enabled = true;
        nextGameButton.gameObject.SetActive(true);

    }
}
