using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadOccludedScene : MonoBehaviour
{
    private AsyncOperation asyncOperation;
    private void OnTriggerEnter(Collider other)
    {
        SummaryStatic.TesteDebug("daora");
        StartCoroutine(LoadOccluded());
    }

    private void OnTriggerExit(Collider other)
    {
        SceneManager.UnloadSceneAsync("SceneOccluded");
    }

    IEnumerator LoadOccluded()
    {
        asyncOperation = SceneManager.LoadSceneAsync("SceneOccluded", LoadSceneMode.Additive);
        asyncOperation.completed += AsyncOperation_completed;
        asyncOperation.allowSceneActivation = false;
        yield return asyncOperation;
    }

    private void AsyncOperation_completed(AsyncOperation obj)
    {
        Debug.Log(asyncOperation.progress);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.V)) { asyncOperation.allowSceneActivation = true; }
    }
}
