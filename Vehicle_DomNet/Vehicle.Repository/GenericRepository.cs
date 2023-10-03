using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Vehicle.DAL;
using Vehicle.Repository.Common;

namespace Vehicle.Repository
{
    public class GenericRepository<TEntity, TModel> : IGenericRepository<TEntity, TModel> where TEntity : class 
    {
        private readonly VehicleContext _db;
        protected readonly DbSet<TEntity> dbSet;
        private readonly IMapper mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GenericRepository(VehicleContext context, IMapper map, IUnitOfWork unitOfWork)
        {
            _db = context;
            dbSet = _db.Set<TEntity>();
            mapper = map;
            _unitOfWork = unitOfWork;

        }

        public virtual async Task<TModel> GetById(int id)
        {
            TEntity model = await dbSet.FindAsync(id);
            return mapper.Map<TModel>(model);
        }

        public virtual async Task<IEnumerable<TModel>> Get()
        {
            return mapper.Map<IEnumerable<TModel>>(dbSet);
        }

        public virtual async Task Add(TModel model)
        {
            try
            {
                TEntity entity = mapper.Map<TEntity>(model);
                await dbSet.AddAsync(entity);
                await _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public virtual async Task Update(TModel model)
        {
            try
            {               
                TEntity entity = mapper.Map<TEntity>(model);
                dbSet.Update(entity);
                await _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                TEntity entity = await dbSet.FindAsync(id);
                _db.Remove(entity);
                await _unitOfWork.Save();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
