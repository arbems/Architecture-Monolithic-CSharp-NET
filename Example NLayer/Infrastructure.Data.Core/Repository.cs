namespace Infrastructure.Data.Core
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    using Domain.Core;
    using Infrastructure.Crosscutting.Logging;
    using Infrastructure.Data.Core.Resources;

    /// <summary>
    /// Repository base class
    /// </summary>
    /// <typeparam name="TEntity">The type of underlying entity in this repository</typeparam>
    public class Repository<TEntity> :IRepository<TEntity>
        where TEntity:Entity
    {
        #region Members

        IQueryableUnitOfWork _UnitOfWork;
       
        #endregion

        #region Constructor

        /// <summary>
        /// Create a new instance of repository
        /// </summary>
        /// <param name="unitOfWork">Associated Unit Of Work</param>
        public Repository(IQueryableUnitOfWork unitOfWork)
        {
            if (unitOfWork == (IUnitOfWork)null)
                throw new ArgumentNullException("unitOfWork");

            _UnitOfWork = unitOfWork;
        }

        #endregion

        #region IRepository Members

        /// <summary>
        /// <see cref="Domain.Core.IRepository{TValueObject}"/>
        /// </summary>
        public IUnitOfWork UnitOfWork
        {
            get 
            {
                return _UnitOfWork;
            }
        }

        /// <summary>
        /// <see cref="Domain.Core.IRepository{TValueObject}"/>
        /// </summary>
        /// <param name="item"><see cref="Domain.Core.IRepository{TValueObject}"/></param>
        public virtual void Add(TEntity item)
        {

            if (item != (TEntity)null)
                GetSet().Add(item); // add new item in this set
            else
            {
                LoggerFactory.CreateLog()
                          .LogInfo(Messages.info_CannotAddNullEntity,typeof(TEntity).ToString());
                
            }
            
        }
        /// <summary>
        /// <see cref="Domain.Core.IRepository{TValueObject}"/>
        /// </summary>
        /// <param name="item"><see cref="Domain.Core.IRepository{TValueObject}"/></param>
        public virtual void Remove(TEntity item)
        {
            if (item != (TEntity)null)
            {
                //attach item if not exist
                _UnitOfWork.Attach(item);

                //set as "removed"
                GetSet().Remove(item);
            }
            else
            {
                LoggerFactory.CreateLog()
                          .LogInfo(Messages.info_CannotRemoveNullEntity, typeof(TEntity).ToString());
            }
        }

        /// <summary>
        /// <see cref="Domain.Core.IRepository{TValueObject}"/>
        /// </summary>
        /// <param name="item"><see cref="Domain.Core.IRepository{TValueObject}"/></param>
        public virtual void TrackItem(TEntity item)
        {
            if (item != (TEntity)null)
                _UnitOfWork.Attach<TEntity>(item);
            else
            {
                LoggerFactory.CreateLog()
                          .LogInfo(Messages.info_CannotRemoveNullEntity, typeof(TEntity).ToString());
            }
        }

        /// <summary>
        /// <see cref="Domain.Core.IRepository{TValueObject}"/>
        /// </summary>
        /// <param name="item"><see cref="Domain.Core.IRepository{TValueObject}"/></param>
        public virtual void Modify(TEntity item)
        {
            if (item != (TEntity)null)
                _UnitOfWork.SetModified(item);
            else
            {
                LoggerFactory.CreateLog()
                          .LogInfo(Messages.info_CannotRemoveNullEntity, typeof(TEntity).ToString());
            }
        }

        /// <summary>
        /// <see cref="Domain.Core.IRepository{TValueObject}"/>
        /// </summary>
        /// <param name="id"><see cref="Domain.Core.IRepository{TValueObject}"/></param>
        /// <returns><see cref="Domain.Core.IRepository{TValueObject}"/></returns>
        public virtual TEntity Get(Guid id)
        {
            if (id != Guid.Empty)
                return GetSet().Find(id);
            else
                return null;
        }
        /// <summary>
        /// <see cref="Domain.Core.IRepository{TValueObject}"/>
        /// </summary>
        /// <returns><see cref="Domain.Core.IRepository{TValueObject}"/></returns>
        public virtual IEnumerable<TEntity> GetAll()
        {
            return GetSet();
        }
        /// <summary>
        /// <see cref="Domain.Core.IRepository{TValueObject}"/>
        /// </summary>
        /// <param name="specification"><see cref="Domain.Core.IRepository{TValueObject}"/></param>
        /// <returns><see cref="Domain.Core.IRepository{TValueObject}"/></returns>
        public virtual IEnumerable<TEntity> AllMatching(Domain.Core.Specification.ISpecification<TEntity> specification)
        {
            return GetSet().Where(specification.SatisfiedBy());
        }
        /// <summary>
        /// <see cref="Domain.Core.IRepository{TValueObject}"/>
        /// </summary>
        /// <typeparam name="S"><see cref="Domain.Core.IRepository{TValueObject}"/></typeparam>
        /// <param name="pageIndex"><see cref="Domain.Core.IRepository{TValueObject}"/></param>
        /// <param name="pageCount"><see cref="Domain.Core.IRepository{TValueObject}"/></param>
        /// <param name="orderByExpression"><see cref="Domain.Core.IRepository{TValueObject}"/></param>
        /// <param name="ascending"><see cref="Domain.Core.IRepository{TValueObject}"/></param>
        /// <returns><see cref="Domain.Core.IRepository{TValueObject}"/></returns>
        public virtual IEnumerable<TEntity> GetPaged<KProperty>(int pageIndex, int pageCount, System.Linq.Expressions.Expression<Func<TEntity, KProperty>> orderByExpression, bool ascending)
        {
            var set = GetSet();

            if (ascending)
            {
                return set.OrderBy(orderByExpression)
                          .Skip(pageCount * pageIndex)
                          .Take(pageCount);
            }
            else
            {
                return set.OrderByDescending(orderByExpression)
                          .Skip(pageCount * pageIndex)
                          .Take(pageCount);
            }
        }
        /// <summary>
        /// <see cref="Domain.Core.IRepository{TValueObject}"/>
        /// </summary>
        /// <param name="filter"><see cref="Domain.Core.IRepository{TValueObject}"/></param>
        /// <returns><see cref="Domain.Core.IRepository{TValueObject}"/></returns>
        public virtual IEnumerable<TEntity> GetFiltered(System.Linq.Expressions.Expression<Func<TEntity, bool>> filter)
        {
            return GetSet().Where(filter);
        }

        /// <summary>
        /// <see cref="Domain.Core.IRepository{TValueObject}"/>
        /// </summary>
        /// <param name="persisted"><see cref="Domain.Core.IRepository{TValueObject}"/></param>
        /// <param name="current"><see cref="Domain.Core.IRepository{TValueObject}"/></param>
        public virtual void Merge(TEntity persisted, TEntity current)
        {
            _UnitOfWork.ApplyCurrentValues(persisted, current);
        }

        #endregion

        #region IDisposable Members

        /// <summary>
        /// <see cref="M:System.IDisposable.Dispose"/>
        /// </summary>
        public void Dispose()
        {
            if (_UnitOfWork != null)
                _UnitOfWork.Dispose();
        }

        #endregion

        #region Private Methods

        IDbSet<TEntity> GetSet()
        {
            return  _UnitOfWork.CreateSet<TEntity>();
        }
        #endregion
    }
}
