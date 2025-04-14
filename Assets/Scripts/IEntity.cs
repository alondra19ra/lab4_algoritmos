using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEntity
{
    string Name { get; }
    Vector3 Position { get; }
}

public interface IEntityStats : IEntity
{
    float Health { get; }
}

