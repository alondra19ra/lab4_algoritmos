using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomNode
{
    public int turnNumber;
    public List<IEntity> entitiesSnapshot;

    public CustomNode Previous;
    public CustomNode Next;

    public CustomNode(int turn, List<IEntity> snapshot)
    {
        turnNumber = turn;
        entitiesSnapshot = snapshot;
    }
}

