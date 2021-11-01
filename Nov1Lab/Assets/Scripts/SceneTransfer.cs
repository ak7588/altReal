using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransfer : MonoBehaviour
{
    // Start is called before the first frame update
    public string toScene = "XR";
    string prevScene = "";
    public bool changeLayer = true;
    public int toLayer = 0;
    int prevLayer = 0;

    public void Transfer() {
        if (gameObject.scene.name == toScene) return;
        if (transform.parent != null) transform.SetParent(null);
        Scene newScene = SceneManager.GetSceneByName(toScene);
        if (newScene.IsValid()) {
            prevScene = gameObject.scene.name;
            prevLayer = gameObject.layer;
            SceneManager.MoveGameObjectToScene(gameObject, newScene);
            if (changeLayer) gameObject.layer = toLayer;
        }
    }

    public void Return() {
        if (prevScene == string.Empty) return;
        Scene previousScene = SceneManager.GetSceneByName(prevScene);
        if (!previousScene.IsValid()) previousScene = SceneManager.GetActiveScene();
        if (changeLayer) gameObject.layer = prevLayer;
        if (gameObject.scene.name == previousScene.name) return;
        SceneManager.MoveGameObjectToScene(gameObject, previousScene);
    }
}
