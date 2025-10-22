using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    public enum SceneNames
    {
        MainMenu,
        Level1,
        LevelSelection,
        SampleScene,
    }
    public static SceneManagerScript instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void OnLoadScene(SceneNames sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName.ToString());
    }
}
