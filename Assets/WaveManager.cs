using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    static readonly string structurePrefix = "Prefab/LevelStructure/LevelStructure";
    static readonly string testPrefix = "Prefab/TestStructure/";

    List<GameObject> waves;
    int waveIndex = 0;

    List<EnemyInformation> enemyInformations;
    int enemyInformationIndex = 0;

    public List<Enemy> enemies;
    public List<Vector3> checkpoints;

    int frame = 0;

    public void LoadStructure(string structureName = "")
    {
        if (structureName == "")
            structureName = structurePrefix + GameDataManager.Instance.currentLevel.ToString();
        else
            structureName = testPrefix + structureName;

        GameObject structure = Instantiate(Resources.Load(structureName)) as GameObject;

        GameObject wave = Enumerable.Range(0, structure.transform.childCount)
            .Select(i => structure.transform.GetChild(i).gameObject)
            .Where(o => o.GetComponentInChildren<EnemyInformation>() != null)
            .FirstOrDefault();

        waves = Enumerable.Range(0, wave.transform.childCount)
            .Select(i => wave.transform.GetChild(i).gameObject)
            .Where(o => o.GetComponent<EnemyInformation>() != null)
            .ToList();

        checkpoints = structure.GetComponentsInChildren<CheckPoint>()
            .Select(c => c.gameObject.transform.position)
            .Select(v => new Vector3(Mathf.Round(v.x), 0, Mathf.Round(v.z)))
            .ToList();
    }

    public void Initialize()
    {
        waveIndex = -1;
        enemyInformationIndex = 0;
        ObjectManager.Instance.GameStateManager.state = GameState.Wave;
        ObjectManager.Instance.WaveManager.StartWave();
    }

    public void StartWave()
    {
        enemies = new List<Enemy>();
        waveIndex++;
        frame = 0;
        enemyInformationIndex = 0;
        enemyInformations = waves[waveIndex].GetComponentsInChildren<EnemyInformation>().ToList();
        Instantiate(PrefabHolder.Instance.waveAnimation).GetComponentsInChildren<TextDisplay>()
            .ToList()
            .ForEach(t => t.Play("Wave " + (waveIndex + 1)));
    }

    public void UpdateFrame()
    {
        frame++;

        if (ObjectManager.Instance.GameStateManager.state == GameState.Wave)
            ObjectManager.Instance.WaveManager.UpdateWave();

        if (ObjectManager.Instance.GameStateManager.state == GameState.Wave)
            ObjectManager.Instance.WaveManager.UpdateEnemiesFrame();

        if (ObjectManager.Instance.GameStateManager.state == GameState.Wave)
            ObjectManager.Instance.WaveManager.UpdateGameState();
    }

    void UpdateWave()
    {
        if (enemyInformationIndex < enemyInformations.Count)
        {
            Enemy enemy = enemyInformations[enemyInformationIndex].Spawn(frame);
            if (enemy != null)
            {
                enemyInformationIndex++;
                enemies.Add(enemy);
            }
        }
    }

    void UpdateEnemiesFrame()
    {
        enemies.ForEach(e => e.UpdateFrame());
    }

    void UpdateGameState()
    {
        if (ObjectManager.Instance.Goal.GetHealth() == 0)
        {
            ObjectManager.Instance.GameStateManager.state = GameState.Fail;
            Instantiate(PrefabHolder.Instance.failAnimation);
        }
        else if (enemies.Count == 0 && enemyInformations.Count - 1 <= enemyInformationIndex)
        {
            if (waves.Count - 1 <= waveIndex)
            {
                ObjectManager.Instance.GameStateManager.state = GameState.Clear;
                Instantiate(PrefabHolder.Instance.endingRose);
            }
            else
            {
                StartWave();
            }
        }
    }

    public void DeregisterEnemy(Enemy enemy)
    {
        enemies = enemies
            .Where(e => e.GetInstanceID() != enemy.GetInstanceID())
            .ToList();
    }

}
