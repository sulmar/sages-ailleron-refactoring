using System.Collections.Generic;

namespace ProxyPattern
{
    // Generyczny pośrednik (Proxy)
    // Wariant obiektowy
    public class CacheEntityRepository<TEntity> : IEntityRepository<TEntity>
        where TEntity : BaseEntity
    {
        private readonly IDictionary<int, TEntity> entities;

        // Real Subject
        private readonly IEntityRepository<TEntity> entityRepository;

        public CacheEntityRepository(IEntityRepository<TEntity> productRepository)
        {
            this.entityRepository = productRepository;

            entities = new Dictionary<int, TEntity>();
        }

        public void Add(TEntity entity)
        {
            entities.Add(entity.Id, entity);
        }

        public TEntity Get(int id)
        {
            if (entities.TryGetValue(id, out TEntity entity))
            {
                entity.CacheHit++;
            }
            else
            {
                entity = entityRepository.Get(id);

                if (entity != null)
                {
                    Add(entity);
                }

            }

            return entity;

        }

    }

}
