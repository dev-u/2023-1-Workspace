using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneController : MonoBehaviour
{
    private bool loadUI = true;
    private IEnumerator Start()
    {
        yield return SceneManager.LoadSceneAsync("SceneCore", LoadSceneMode.Additive);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
            UpdateUI(loadUI);
    }

    private void UpdateUI(bool loadUI)
    {
        this.loadUI = !loadUI;

        if (loadUI)
            SceneManager.LoadScene("SceneUI", LoadSceneMode.Additive);
        else
            SceneManager.UnloadSceneAsync("SceneUI");

    }
}
