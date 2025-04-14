using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour, IEntityStats
{
    public string entityName;
    public float health = 100f;

    public string Name
    {
        get { return entityName; }
    }

    public Vector3 Position
    {
        get { return transform.position; }
    }

    public float Health
    {
        get { return health; }
    }
}

