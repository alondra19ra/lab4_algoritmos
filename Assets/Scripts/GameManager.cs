using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;
using Alondra;
using TMPro;

public class GameManager : MonoBehaviour
{
    [LabelText("Entidades del juego")]
    [ListDrawerSettings(Expanded = true)]
    public List<Entity> entities;

    [LabelText("Texto del turno actual")]
    public TMP_Text turnText;

    private int turnCounter = 0;
    private CustomDoubleLinkedList turnList = new CustomDoubleLinkedList();

    [Button("Registrar Turno Actual")]
    public void RegisterTurn()
    {
        List<IEntity> snapshot = GameUtils.SnapshotEntities(entities);
        CustomNode newNode = new CustomNode(turnCounter++, snapshot);
        turnList.Add(newNode);
        UpdateUI();
    }

    [Button("← Turno Anterior")]
    public void PreviousTurn()
    {
        turnList.MoveToPrevious();
        ApplySnapshot();
        UpdateUI();
    }

    [Button("→ Turno Siguiente")]
    public void NextTurn()
    {
        turnList.MoveToNext();
        ApplySnapshot();
        UpdateUI();
    }

    private void ApplySnapshot()
    {
        List<IEntity> snapshot = turnList.GetCurrentEntities();
        if (snapshot != null && snapshot.Count > 0)
        {
            for (int i = 0; i < snapshot.Count && i < entities.Count; i++)
            {
                entities[i].transform.position = snapshot[i].Position;

                IEntityStats stats = snapshot[i] as IEntityStats;
                if (stats != null)
                {
                    entities[i].health = stats.Health;
                }
            }
        }
    }

    private void UpdateUI()
    {
        var currentNode = turnList.GetCurrent();
        if (turnText != null && currentNode != null)
        {
            turnText.text = "Turno actual: " + currentNode.turnNumber;
        }
        else if (turnText != null)
        {
            turnText.text = "Turno actual: -";
        }
    }


    private void Start()
    {
        RegisterTurn();
    }
}



