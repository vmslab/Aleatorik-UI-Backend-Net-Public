using AleatorikUI.Services.DTO.mdm;
using SqlBatis.DataMapper;

namespace AleatorikUI.Services.DAO.mdm;

public class MdmCustInfoDao : IMdmCustInfoDao
{
    public MdmCustInfoDao(ISqlMapper mapper)
    {
        Mapper = mapper;
    }

    private ISqlMapper Mapper { get; }

    public IEnumerable<MdmCustInfo> GetAll()
    {
        return Mapper.QueryForList<MdmCustInfo>("MdmCustInfo.Select", null);
    }

    public void Insert(MdmCustInfo mdmCustInfo)
    {
        Mapper.Insert("MdmCustInfo.Insert", mdmCustInfo);
    }

    public int Update(MdmCustInfo mdmCustInfo)
    {
        return Mapper.Update("MdmCustInfo.Update", mdmCustInfo);
    }

    public int Delete(MdmCustInfo mdmCustInfo)
    {
        return Mapper.Delete("MdmCustInfo.Delete", mdmCustInfo);
    }
}