using System;
using System.Collections.Generic;
using System.Text;

namespace MathForGames
{
    class Scene
    {
        private Entity[] _entities;

        public Scene()
        {
            _entities = new Entity[0];
        }

        public void AddEntity(Entity entity)
        {
            Entity[] newEntities = new Entity[_entities.Length + 1];
            for (int i = 0; i < _entities.Length; i++)
            {
                newEntities[i] = _entities[i];
            }
            newEntities[_entities.Length] = entity;
            _entities = newEntities;
        }
        
        public void Start()
        {

        }

        public void Update()
        {

        }

        public void Draw()
        {

        }

        public void End()
        {

        }
    }
}
