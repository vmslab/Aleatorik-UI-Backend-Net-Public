using AleatorikUI.Services.DTO.mdm;
using SqlBatis.DataMapper;

namespace AleatorikUI.Services.DAO.mdm;

public class MdmBufferDao : IMdmBufferDao
{
    public MdmBufferDao(ISqlMapper mapper)
    {
        Mapper = mapper;
    }

    private ISqlMapper Mapper { get; }

    public IEnumerable<MdmBuffer> GetAll()
    {
        return Mapper.QueryForList<MdmBuffer>("MdmBuffer.Select", null);
    }

    public void Insert(MdmBuffer mdmBuffer)
    {
        Mapper.Insert("MdmBuffer.Insert", mdmBuffer);
    }

    public int Update(MdmBuffer mdmBuffer)
    {
        return Mapper.Update("MdmBuffer.Update", mdmBuffer);
    }

    public int Delete(MdmBuffer mdmBuffer)
    {
        return Mapper.Delete("MdmBuffer.Delete", mdmBuffer);
    }
}