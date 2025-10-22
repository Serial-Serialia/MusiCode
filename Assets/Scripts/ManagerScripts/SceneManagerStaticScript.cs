
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerStaticScript : MonoBehaviour
{
    public void OnLoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
