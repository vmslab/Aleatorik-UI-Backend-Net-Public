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

    public IEnumerable<MdmCustMaster> GetAll()
    {
        return Mapper.QueryForList<MdmCustMaster>("MdmCustMaster.Select", null);
    }

    public void Insert(MdmCustMaster mdmCustInfo)
    {
        Mapper.Insert("MdmCustMaster.Insert", mdmCustInfo);
    }

    public int Update(MdmCustMaster mdmCustInfo)
    {
        return Mapper.Update("MdmCustMaster.Update", mdmCustInfo);
    }

    public int Delete(MdmCustMaster mdmCustInfo)
    {
        return Mapper.Delete("MdmCustMaster.Delete", mdmCustInfo);
    }

    /**
    *  CUST PROP
    */
    public IEnumerable<MdmCustProp> GetAllProp(string custID)
    {
        return Mapper.QueryForList<MdmCustProp>("MdmCustProp.Select", custID);
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