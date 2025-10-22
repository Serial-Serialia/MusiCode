using UnityEngine;
using UnityEngine.UIElements;

public class LevelSelectionScript : MonoBehaviour
{
    private UIDocument _document;
    private Button _Level1Button;
    private Button _BackButton;

    void Awake()
    {
        _document = GetComponent<UIDocument>();
        _Level1Button = _document.rootVisualElement.Q("Level1Button") as Button;
        _BackButton = _document.rootVisualElement.Q("BackButton") as Button;

        _Level1Button.RegisterCallback<ClickEvent>(OnLevel1Button);
        _BackButton.RegisterCallback<ClickEvent>(OnBackButton);
    }

    void OnDisable()
    {
        _Level1Button.UnregisterCallback<ClickEvent>(OnLevel1Button);
        _BackButton.UnregisterCallback<ClickEvent>(OnBackButton);
    }

    private void OnLevel1Button(ClickEvent clickEvent)
    {
        SceneManagerScript.instance.OnLoadScene(SceneManagerScript.SceneNames.Level1);
    }

    private void OnBackButton(ClickEvent clickEvent)
    {
        SceneManagerScript.instance.OnLoadScene(SceneManagerScript.SceneNames.MainMenu);

    }
}
