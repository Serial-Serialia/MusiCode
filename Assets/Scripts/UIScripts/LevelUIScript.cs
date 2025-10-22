using UnityEngine;
using UnityEngine.UIElements;

public class LevelUIScript : MonoBehaviour
{
    private UIScript LogicManager;
    private UIDocument _document;
    private Button _PlayButton;
    private Button _PauseButton;
    private Button _StopButton;
    private Button _RestartButton;
    private Button _BackButton;

    void Awake()
    {
        LogicManager = GameObject.FindGameObjectWithTag("Logic_manager").GetComponent<UIScript>();

        _document = GetComponent<UIDocument>();
        _PlayButton = _document.rootVisualElement.Q("PlayButton") as Button;
        _PauseButton = _document.rootVisualElement.Q("PauseButton") as Button;
        _StopButton = _document.rootVisualElement.Q("StopButton") as Button;
        _RestartButton = _document.rootVisualElement.Q("RestartButton") as Button;
        _BackButton = _document.rootVisualElement.Q("BackButton") as Button;

        _PlayButton.RegisterCallback<ClickEvent>(OnPlayButton);
        _PauseButton.RegisterCallback<ClickEvent>(OnPauseButton);
        _StopButton.RegisterCallback<ClickEvent>(OnStopButton);
        _RestartButton.RegisterCallback<ClickEvent>(OnRestartButton);
        _BackButton.RegisterCallback<ClickEvent>(OnBackButton);
    }

    void OnDisable()
    {
        _PlayButton.UnregisterCallback<ClickEvent>(OnPlayButton);
        _PauseButton.UnregisterCallback<ClickEvent>(OnPauseButton);
        _StopButton.UnregisterCallback<ClickEvent>(OnStopButton);
        _RestartButton.UnregisterCallback<ClickEvent>(OnRestartButton);
        _BackButton.UnregisterCallback<ClickEvent>(OnBackButton);
    }

    private void OnPlayButton(ClickEvent evn)
    {
        LogicManager.Play();
    }

    private void OnPauseButton(ClickEvent evn)
    {
        LogicManager.Pause();
    }

    private void OnStopButton(ClickEvent env)
    {
        LogicManager.Stop();
    }
    private void OnRestartButton(ClickEvent env)
    {
        SceneManagerScript.instance.OnLoadScene(SceneManagerScript.SceneNames.Level1);
    }
    private void OnBackButton(ClickEvent env)
    {
        SceneManagerScript.instance.OnLoadScene(SceneManagerScript.SceneNames.LevelSelection);
    }
    
}
