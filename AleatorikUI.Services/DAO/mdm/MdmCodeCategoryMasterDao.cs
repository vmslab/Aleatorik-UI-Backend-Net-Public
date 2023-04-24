using AleatorikUI.Services.DTO.mdm;
using SqlBatis.DataMapper;

namespace AleatorikUI.Services.DAO.mdm;

public class MdmCodeCategoryMasterDao : IMdmCodeCategoryMasterDao
{
    public MdmCodeCategoryMasterDao(ISqlMapper mapper)
    {
        Mapper = mapper;
    }

    private ISqlMapper Mapper { get; }

    public IEnumerable<MdmCodeCategoryMaster> GetAll(MdmCodeCategoryMaster mdmCodeCategoryMaster)
    {
        return Mapper.QueryForList<MdmCodeCategoryMaster>("MdmCodeCategoryMaster.Select", mdmCodeCategoryMaster);
    }

    public void Insert(MdmCodeCategoryMaster mdmCodeCategoryMaster)
    {
        Mapper.Insert("MdmCodeCategoryMaster.Insert", mdmCodeCategoryMaster);
    }

    public int Update(MdmCodeCategoryMaster mdmCodeCategoryMaster)
    {
        return Mapper.Update("MdmCodeCategoryMaster.Update", mdmCodeCategoryMaster);
    }

    public int Delete(MdmCodeCategoryMaster mdmCodeCategoryMaster)
    {
        return Mapper.Delete("MdmCodeCategoryMaster.Delete", mdmCodeCategoryMaster);
    }

    /**
     * Code Master
     */
    public IEnumerable<MdmCodeMaster> GetAllMaster(MdmCodeMaster mdmCodeMaster)
    {
        return Mapper.QueryForList<MdmCodeMaster>("MdmCodeMaster.Select", mdmCodeMaster);
    }

    public void InsertMaster(MdmCodeMaster mdmCodeMaster)
    {
        Mapper.Insert("MdmCodeMaster.Insert", mdmCodeMaster);
    }

    public int UpdateMaster(MdmCodeMaster mdmCodeMaster)
    {
        return Mapper.Update("MdmCodeMaster.Update", mdmCodeMaster);
    }

    public int DeleteMaster(MdmCodeMaster mdmCodeMaster)
    {
        return Mapper.Delete("MdmCodeMaster.Delete", mdmCodeMaster);
    }
}