using DAL;
using Repository;

GenericUnitOfWork unitOfWork = new GenericUnitOfWork(new ApplicationDbContext());

IGenericRepository<Category> genericRepository = unitOfWork.Repository<Category>();

genericRepository.Add(new Category { Name = "Electronics" });
