using System.Collections.Generic;
using UnityEngine;

namespace Alondra
{
    public static class GameUtils
    {
        public static List<IEntity> SnapshotEntities(List<Entity> currentEntities)
        {
            List<IEntity> snapshot = new List<IEntity>();

            foreach (Entity entity in currentEntities)
            {
                snapshot.Add(new EntityData(entity));
            }

            return snapshot;
        }

        private class EntityData : IEntityStats
        {
            public string Name { get; private set; }
            public Vector3 Position { get; private set; }
            public float Health { get; private set; }

            public EntityData(Entity entity)
            {
                Name = entity.Name;
                Position = entity.Position;
                Health = entity.health;
            }
        }
    }
}


