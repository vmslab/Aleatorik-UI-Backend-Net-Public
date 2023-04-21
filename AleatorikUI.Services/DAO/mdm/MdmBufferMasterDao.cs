using AleatorikUI.Services.DTO.mdm;
using SqlBatis.DataMapper;

namespace AleatorikUI.Services.DAO.mdm;

public class MdmBufferMasterDao : IMdmBufferMasterDao
{
    public MdmBufferMasterDao(ISqlMapper mapper)
    {
        Mapper = mapper;
    }

    private ISqlMapper Mapper { get; }

    public IEnumerable<MdmBufferMaster> GetAll(MdmBufferMaster mdmBufferMaster)
    {
        return Mapper.QueryForList<MdmBufferMaster>("MdmBufferMaster.Select", mdmBufferMaster);
    }

    public void Insert(MdmBufferMaster mdmBufferMaster)
    {
        Mapper.Insert("MdmBufferMaster.Insert", mdmBufferMaster);
    }

    public int Update(MdmBufferMaster mdmBufferMaster)
    {
        return Mapper.Update("MdmBufferMaster.Update", mdmBufferMaster);
    }

    public int Delete(MdmBufferMaster mdmBufferMaster)
    {
        return Mapper.Delete("MdmBufferMaster.Delete", mdmBufferMaster);
    }

    /**
      *  BUFFER PROP
      */
    public IEnumerable<MdmBufferProp> GetAllProp(MdmBufferProp mdmBufferProp)
    {
        return Mapper.QueryForList<MdmBufferProp>("MdmBufferProp.Select", mdmBufferProp);
    }

    public void InsertProp(MdmBufferProp mdmBufferProp)
    {
        Mapper.Insert("MdmBufferProp.InsertProp", mdmBufferProp);
    }

    public int UpdateProp(MdmBufferProp mdmBufferProp)
    {
        return Mapper.Update("MdmBufferProp.Update", mdmBufferProp);
    }

    public int DeleteProp(MdmBufferProp mdmBufferProp)
    {
        return Mapper.Delete("MdmBufferProp.Delete", mdmBufferProp);
    }


}