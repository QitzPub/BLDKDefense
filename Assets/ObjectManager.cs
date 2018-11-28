using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectManager : SingletonMonoBehaviour<ObjectManager>
{
    new void Awake()
    {
        base.Awake();
    }

    private GameStateManager gameStateManager;
    public GameStateManager GameStateManager {
        get
        {
            if (gameStateManager == null)
            {
                gameStateManager = new GameStateManager();
            }
            return gameStateManager;
        }
        private set { }
    }

    [SerializeField] LevelSelectManager levelSelectManagerPrefab;
    private LevelSelectManager levelSelectManager;
    public LevelSelectManager LevelSelectManager
    {
        get
        {
            if (levelSelectManager == null)
            {
                levelSelectManager = Instantiate(levelSelectManagerPrefab);
            }
            return levelSelectManager;
        }
        private set { }
    }

    [SerializeField] LevelDisplay levelDisplayPrefab;
    private LevelDisplay levelDisplay;
    public LevelDisplay LevelDisplay
    {
        get
        {
            if (levelDisplay == null)
            {
                levelDisplay = Instantiate(levelDisplayPrefab);
            }
            return levelDisplay;
        }
        private set { }
    }

    [SerializeField] WaveManager waveManagerPrefab;
    private WaveManager waveManager;
    public WaveManager WaveManager
    {
        get
        {
            if (waveManager == null)
            {
                waveManager = Instantiate(waveManagerPrefab);
            }
            return waveManager;
        }
        private set { }
    }

    [SerializeField] EnemySpawner enemyManagerPrefab;
    private EnemySpawner enemyManager;
    public EnemySpawner EnemyManager
    {
        get
        {
            if (enemyManager == null)
            {
                enemyManager = Instantiate(enemyManagerPrefab);
            }
            return enemyManager;
        }
        private set { }
    }

    [SerializeField] LevelCamera levelCameraPrefab;
    private LevelCamera levelCamera;
    public LevelCamera LevelCamera
    {
        get
        {
            if (levelCamera == null)
            {
                levelCamera = FindObjectOfType<LevelCamera>() ?? Instantiate(levelCameraPrefab);
            }
            return levelCamera;
        }
        private set { }
    }

    [SerializeField] GameObject levelLightPrefab;
    private GameObject levelLight;
    public GameObject LevelLight
    {
        get
        {
            if (levelLight == null)
            {
                levelLight = Instantiate(levelLightPrefab);
            }
            return levelLight;
        }
        private set { }
    }

    private Goal goal;
    public Goal Goal
    {
        get { return goal = goal ?? FindObjectOfType<Goal>(); }
        private set { }
    }

    [SerializeField] InputManager levelInputManagerPrefab;
    private InputManager levelInputManager;
    public InputManager LevelInputManager
    {
        get
        {
            if (levelInputManager == null)
            {
                levelInputManager = Instantiate(levelInputManagerPrefab);
            }
            return levelInputManager;
        }
        private set { }
    }

    [SerializeField] LevelProgressManager levelProgressManagerPrefab;
    private LevelProgressManager levelProgressManager;
    public LevelProgressManager LevelProgressManager
    {
        get
        {
            if (levelProgressManager == null)
            {
                levelProgressManager = Instantiate(levelProgressManagerPrefab);
            }
            return levelProgressManager;
        }
        private set { }
    }

    [SerializeField] Canvas levelCanvasPrefab;
    private Canvas levelCanvas;
    public Canvas LevelCanvas
    {
        get
        {
            if (levelCanvas == null)
            {
                levelCanvas = Instantiate(levelCanvasPrefab);
            }
            return levelCanvas;
        }
        private set { }
    }

    [SerializeField] EventSystem eventSystemPrefab;
    private EventSystem eventSystem;
    public EventSystem EventSystem
    {
        get
        {
            if (eventSystem == null)
            {
                eventSystem = Instantiate(eventSystemPrefab);
            }
            return eventSystem;
        }
        private set { }
    }
}
