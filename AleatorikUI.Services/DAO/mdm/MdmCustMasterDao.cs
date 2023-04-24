using AleatorikUI.Services.DTO.mdm;
using SqlBatis.DataMapper;

namespace AleatorikUI.Services.DAO.mdm;

public class MdmCustMasterDao : IMdmCustMasterDao
{
    public MdmCustMasterDao(ISqlMapper mapper)
    {
        Mapper = mapper;
    }

    private ISqlMapper Mapper { get; }

    public IEnumerable<MdmCustMaster> GetAll(MdmCustMaster mdmCustMaster)
    {
        return Mapper.QueryForList<MdmCustMaster>("MdmCustMaster.Select", mdmCustMaster);
    }

    public void Insert(MdmCustMaster mdmCustMaster)
    {
        Mapper.Insert("MdmCustMaster.Insert", mdmCustMaster);
    }

    public int Update(MdmCustMaster mdmCustMaster)
    {
        return Mapper.Update("MdmCustMaster.Update", mdmCustMaster);
    }

    public int Delete(MdmCustMaster mdmCustMaster)
    {
        return Mapper.Delete("MdmCustMaster.Delete", mdmCustMaster);
    }

    /**
    *  CUST PROP
    */
    public IEnumerable<MdmCustProp> GetAllProp(MdmCustProp mdmCustProp)
    {
        return Mapper.QueryForList<MdmCustProp>("MdmCustProp.Select", mdmCustProp);
    }

    public void InsertProp(MdmCustProp mdmCustProp)
    {
        Mapper.Insert("MdmCustProp.InsertProp", mdmCustProp);
    }

    public int UpdateProp(MdmCustProp mdmCustProp)
    {
        return Mapper.Update("MdmCustProp.Update", mdmCustProp);
    }

    public int DeleteProp(MdmCustProp mdmCustProp)
    {
        return Mapper.Delete("MdmCustProp.Delete", mdmCustProp);
    }
}