using UnityEngine;
using UnityEngine.UIElements;

public class MainMenuScript : MonoBehaviour
{
    private UIDocument _document;
    private Button _PlayButton;
    private Button _SettingsButton;
    private Button _ExitButton;

    void Awake()
    {
        _document = GetComponent<UIDocument>();
        _PlayButton = _document.rootVisualElement.Q("PlayButton") as Button;
        //_SettingsButton = _document.rootVisualElement.Q("SettingsButton") as Button;
        _ExitButton = _document.rootVisualElement.Q("ExitButton") as Button;

        _PlayButton.RegisterCallback<ClickEvent>(OnPlayButton);
        //_SettingsButton.RegisterCallback<ClickEvent>(OnSettingsButton);
        _ExitButton.RegisterCallback<ClickEvent>(OnExitButton);
    }

    void OnDisable()
    {
        _PlayButton.UnregisterCallback<ClickEvent>(OnPlayButton);
        //_SettingsButton.UnregisterCallback<ClickEvent>(OnSettingsButton);
        _ExitButton.UnregisterCallback<ClickEvent>(OnExitButton);
    }

    private void OnPlayButton(ClickEvent evn)
    {
        SceneManagerScript.instance.OnLoadScene(SceneManagerScript.SceneNames.LevelSelection);
    }

    /*private void OnSettingsButton(ClickEvent evn)
    {
        Debug.Log("Apertei o Botão");
    }*/

    private void OnExitButton(ClickEvent evn)
    {
        Application.Quit();
    }
}
