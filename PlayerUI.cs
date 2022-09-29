using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.Events;

public class PlayerUI : MonoBehaviour
{
    [SerializeField]
    public WinLose _winLose;

    [SerializeField]
    public Snake _snake;

    [SerializeField]
    public TMPro.TextMeshProUGUI _requredBodyesStatus;

    [SerializeField]
    private GameObject _menuPanel;

    [SerializeField]
    private GameObject _loadingPanel;

    [SerializeField]
    private GameObject _playPanel;

    [SerializeField]
    private GameObject _losePanel;

    [SerializeField]
    private GameObject _WinPanel;

    [SerializeField]
    private GameObject _playButtonWithImage;

    public bool isMusic = true, isSound = true;

    [SerializeField]
    private Slider _slider;

    [SerializeField]
    private Image _backgroundImage;

    [SerializeField]
    public UnityEvent _loadingDone;

    public void Start()
    {
        ShowMenu();
    }

    public void UpdateRequredBodyesStatus() {
        _requredBodyesStatus.text = _snake.body.Count + " / " + _winLose._snakeBodyesToWin;
    }

    public void ShowMenu() {
        _menuPanel.transform.DOLocalMoveY(0, 1); 
    }

    public void HideMenu() {
        _menuPanel.transform.DOLocalMoveY(800, 1);
    }

    public void ShowLoading() {
        _loadingPanel.transform.DOLocalMoveY(0, 1);

        StartCoroutine(SimulateLoadingProcess());
    }

    public void HideLoading()
    {
        _loadingPanel.transform.DOLocalMoveY(800, 1);
    }

    public void ShowPlay()
    {
        _playPanel.transform.DOLocalMoveY(0, 1);
    }

    public void HidePlay()
    {
        _playPanel.transform.DOLocalMoveY(800, 1);
    }

    public void SwithMusic() 
    {
       isMusic = !isMusic; Debug.Log("Music: " + isMusic); 
    }

    public void SwithSound()
    {
        isSound = !isSound; Debug.Log("Sound: " + isSound); 
    }

    private IEnumerator SimulateLoadingProcess() {

        while (_slider.value < _slider.maxValue) {
            yield return new WaitForSeconds(0.2f);
            _slider.value++;
        }

        _slider.value = 0;

        _loadingDone.Invoke();
    }
    public void ShowBackground() {
        _backgroundImage.DOFade(255, 1);
        _backgroundImage.transform.DOLocalMoveY(0, 0);
    }

    public void HideBackground()
    {
        _backgroundImage.DOFade(0, 1);
        _backgroundImage.transform.DOLocalMoveY(800, 0);
    }

    public void ShowLose() {
        _losePanel.transform.DOLocalMoveY(0, 1);
    }

    public void HideLose() {
        _losePanel.transform.DOLocalMoveY(800, 1);
    }

    public void ShowWin() {
        _WinPanel.transform.DOLocalMoveY(0, 1);
    }

    public void HideWin()
    {
        _WinPanel.transform.DOLocalMoveY(800, 1);
    }
}
