using AleatorikUI.Services.DTO.plm;
using SqlBatis.DataMapper;

namespace AleatorikUI.Services.DAO.plm;

public class PlmFactorMasterDao : IPlmFactorMasterDao
{
    public PlmFactorMasterDao(ISqlMapper mapper)
    {
        Mapper = mapper;
    }

    private ISqlMapper Mapper { get; }

    public IEnumerable<PlmFactorMaster> GetAll(PlmFactorMaster plmFactorMaster)
    {
        return Mapper.QueryForList<PlmFactorMaster>("PlmFactorMaster.Select", plmFactorMaster);
    }

    public void Insert(PlmFactorMaster plmFactorMaster)
    {
        Mapper.Insert("PlmFactorMaster.Insert", plmFactorMaster);
    }

    public int Update(PlmFactorMaster plmFactorMaster)
    {
        return Mapper.Update("PlmFactorMaster.Update", plmFactorMaster);
    }

    public int Delete(PlmFactorMaster plmFactorMaster)
    {
        return Mapper.Delete("PlmFactorMaster.Delete", plmFactorMaster);
    }
}