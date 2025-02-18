using DisneyBattle.BLL.Interfaces;
using DisneyBattle.DAL;
using DisneyBattle.DAL.Entities;
using DisneyBattle.DAL.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

    namespace DisneyBattle.BLL.Services;
public class PersonnageService : IService<Personnage>
{
    private readonly IUnitOfWork _unitOfWork;

    public PersonnageService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Personnage>> GetAllAsync()
    {
        return await _unitOfWork.Personnages.GetAllAsync();
    }

    public async Task<Personnage> GetByIdAsync(int id)
    {
        return await _unitOfWork.Personnages.GetByIdAsync(id);
    }

    public async Task AddAsync(Personnage entity)
    {
        await _unitOfWork.Personnages.AddAsync(entity);
    }

    public async Task UpdateAsync(Personnage entity)
    {
        await _unitOfWork.Personnages.UpdateAsync(entity);
    }

    public async Task DeleteAsync(int id)
    {
        await _unitOfWork.Personnages.DeleteAsync(id);
    }
}
