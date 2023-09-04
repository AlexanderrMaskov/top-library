using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using top_library_models.Models;

namespace top_library_dblayer
{
    public partial class EntityGateway : IDisposable
    {

        private LibraryContext Context { get; init; } = new();
        /// <summary>
        /// Adds or updates one or many entities
        /// </summary>
        /// <param name="entities">one or many entities for adding or updating</param>
        /// <returns><see cref="IEntity.Id"/> if it was one entity. <see cref="cref="Guid.Empty"/></returns>

        public Guid AddOrUpdate(params IEntity[] entities)
        {
           /* if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            if (entity.Id != Guid.Empty)
                Context.Update(entity);
            else
                Context.Add(entity);
           Context.SaveChanges();
            return entity.Id;
           */
           var toAdd = entities.Where(x => x.Id == Guid.Empty).ToArray();
           var toUpdate = entities.Except(toAdd).ToArray();

           Context.UpdateRange(toUpdate);
           Context.AddRange(toAdd);
           Context.SaveChanges();

           if (entities.Length == 1)
               return entities[0].Id;
           else
               return Guid.Empty;
        }

        public bool Delete(params IEntity[] entities)
        {
            Context.RemoveRange(entities);
            return Context.SaveChanges() == entities.Length;
        }

        #region IDisposable implementation
        private bool disposedValue;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
