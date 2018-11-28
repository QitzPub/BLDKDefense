using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum SceneType
{
    Title,
    LevelSelect,
    Level,
}

public class SceneInitializer : SingletonMonoBehaviour<SceneInitializer>
{
    void InitializeGame()
    {
        Physics.autoSimulation = false;
    }

    public void InitializeScene(SceneType type, string structureName = "")
    {
        InitializeGame();
        StartCoroutine(InitializeSceneCoroutine(type, structureName));
    }

    public IEnumerator InitializeSceneCoroutine(SceneType type, string structureName = "") {
        switch (type)
        {
            case SceneType.Title:
                yield return SceneManager.LoadSceneAsync(type.ToString());
                yield return new WaitForSeconds(1f);
                GameDataManager.Instance.SetCanvasActive(false);
                var titleCamera = ObjectManager.Instance.LevelCamera;
                var titleLight = ObjectManager.Instance.LevelLight;
                var titleEventSystem = ObjectManager.Instance.EventSystem;
                Instantiate(PrefabHolder.Instance.titleManager).Animate();
                break;
            case SceneType.LevelSelect:
                var levelSelectManager = ObjectManager.Instance.LevelSelectManager;
                var levelDisplay = ObjectManager.Instance.LevelDisplay;
                break;
            case SceneType.Level:
                yield return SceneManager.LoadSceneAsync(type.ToString());
                yield return new WaitForSeconds(1f);
                ObjectManager.Instance.GameStateManager.state = GameState.Wave;
                GameDataManager.Instance.InitializeForGameScene();
                var enemyManager = ObjectManager.Instance.EnemyManager;
                var camera = ObjectManager.Instance.LevelCamera;
                var light = ObjectManager.Instance.LevelLight;
                var canvas = ObjectManager.Instance.LevelCanvas;
                var inputManager = ObjectManager.Instance.LevelInputManager;
                var eventSystem = ObjectManager.Instance.EventSystem;
                var progressManager = ObjectManager.Instance.LevelProgressManager;
                var waveManager = ObjectManager.Instance.WaveManager;
                waveManager.LoadStructure(structureName);
                waveManager.Initialize();
                break;
        }
    }
}