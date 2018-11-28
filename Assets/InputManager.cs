using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : AbstractInputManager
{
    [SerializeField] UnitSpawner unitSpawner;
    [SerializeField] GameObject cursorIndicaterPrefab;
    MainCharacter mainCharacter;
    GameObject cursorIndicater;

    UnitCursor unitCursor = new UnitCursor();

    void Start()
    {
        cursorIndicater = Instantiate(cursorIndicaterPrefab);
        cursorIndicater.SetActive(false);

        mainCharacter = FindObjectOfType<MainCharacter>();

        updateMousePoint = () =>
        {
            unitCursor.inputMousePosition(Input.mousePosition);
            if (unitCursor.HasFoundTile())
            {
                cursorIndicater.transform.position = unitCursor.GetSpawnPoint(false);
                cursorIndicater.SetActive(true);
                mainCharacter.LookAt(unitCursor.GetSpawnPoint(false));
            }
            else
            {
                cursorIndicater.SetActive(false);
            }
        };

        onPressMouseLeftButtonDown = () =>
        {
            ClickTileOrUI(true);
        };

        onPressMouseRightButtonDown = () =>
        {
            ClickTileOrUI(false);
        };

        onPressEsc = () =>
        {
            SceneInitializer.Instance.InitializeScene(SceneType.Level);
        };

    }

    new void Update()
    {
        base.Update();
        updateMousePoint();
        ObjectManager.Instance.LevelCamera.UpdateMousePosition();
    }

    public InputAccepter FindInputAccepter()
    {
        PointerEventData pointer = new PointerEventData(EventSystem.current);
        pointer.position = Input.mousePosition;
        List<RaycastResult> result = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointer, result);
        return result
            .Where(r => r.gameObject.layer == LayerUtility.GetLayerNumber(LayerName.InputAccepter))
            .Select(r => r.gameObject.GetComponent<InputAccepter>())
            .FirstOrDefault();
    }

    void ClickTileOrUI(bool left)
    {
        var accepter = FindInputAccepter();
        if (accepter == null)
        {
            if (unitCursor.HasFoundTile())
            {
                AbstractAttack attack = null;
                if (left)
                {
                    attack = new RoundAttack(unitCursor.GetSpawnPoint(false));
                }
                else
                {
                    attack = new StraightAttack(unitCursor.GetSpawnPoint(false));
                }

                if (attack.GetComsumption() <= GameDataManager.Instance.UnitPower)
                {
                    mainCharacter.AnimateAttack();
                    attack.Animate(unitCursor.GetSpawnPoint(false));
                    ObjectManager.Instance.WaveManager.enemies
                                 .Where(e => attack.IsInRange(e.transform.position))
                                 .ToList()
                                 .ForEach(e => e.Damaged(attack.GetDamage()));
                    GameDataManager.Instance.UnitPower -= attack.GetComsumption();
                }
            }
        }
        else
        {
            accepter.Execute();
        }
    }

}
