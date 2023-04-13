using AleatorikUI.Services.DTO.mdm;
using SqlBatis.DataMapper;

namespace AleatorikUI.Services.DAO.mdm;

public class MdmFactoryOperDao : IMdmFactoryOperDao
{
    public MdmFactoryOperDao(ISqlMapper mapper)
    {
        Mapper = mapper;
    }

    private ISqlMapper Mapper { get; }

    public IEnumerable<MdmFactoryOper> GetAll()
    {
        return Mapper.QueryForList<MdmFactoryOper>("MdmFactoryOper.Select", null);
    }

    public void Insert(MdmFactoryOper mdmFactoryOper)
    {
        Mapper.Insert("MdmFactoryOper.Insert", mdmFactoryOper);
    }

    public int Update(MdmFactoryOper mdmFactoryOper)
    {
        return Mapper.Update("MdmFactoryOper.Update", mdmFactoryOper);
    }

    public int Delete(MdmFactoryOper mdmFactoryOper)
    {
        return Mapper.Delete("MdmFactoryOper.Delete", mdmFactoryOper);
    }
}