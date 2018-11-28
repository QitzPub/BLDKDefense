using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class InputAccepter : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] List<GameState> validStates;
    protected InputBehaviour inputBehaviour;

    public void Execute()
    {
        if (validStates.Contains(ObjectManager.Instance.GameStateManager.state))
        {
            inputBehaviour?.Execute();
        }
        else
        {
            SoundManager.Instance.Play(SE.Cansell);
            Debug.Log(gameObject.name + " - InvalidState: Expected" + string.Join(", ", validStates) + "but " + ObjectManager.Instance.GameStateManager.state);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {

    }

}
