using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WinLose : MonoBehaviour
{
    [SerializeField]
    public Snake _snake;

    [SerializeField]
    public int _snakeBodyesToWin;

    [SerializeField]
    public int _snakeBodyesToLose;

    [SerializeField]
    public UnityEvent _win;

    [SerializeField]
    public UnityEvent _lose;

    [SerializeField]
    public UnityEvent _gameOver;

    [SerializeField]
    public UnityEvent _createNewGame;

    [SerializeField]
    public UnityEvent _play;

    [SerializeField]
    public UnityEvent _pause;

    private bool isPlaying = false;

    public void CheckGameState() {
        if (isPlaying) {
            if (_snake.body.Count >= _snakeBodyesToWin) { SetWin(); return; }
            if (_snake.body.Count < _snakeBodyesToLose) { SetLose(); }
        }
        
    }

    public void SetPause() {
        _pause.Invoke();
    }

    public void SetBuildingNewGame() {
        _createNewGame.Invoke();
    }
    public void SetWin() {
        isPlaying = false;
        _gameOver.Invoke();
        _win.Invoke();
    }
    public void SetLose() {
        isPlaying = false;
        _gameOver.Invoke();
        _lose.Invoke();
    }
    public void SetPlay() {
        isPlaying = true;
        _play.Invoke();
    }
}
