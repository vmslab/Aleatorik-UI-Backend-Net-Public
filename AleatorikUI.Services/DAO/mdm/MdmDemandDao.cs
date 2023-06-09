﻿using AleatorikUI.Services.DTO.iod;
using AleatorikUI.Services.DTO.mdm;
using SqlBatis.DataMapper;

namespace AleatorikUI.Services.DAO.mdm;

public class MdmDemandDao : IMdmDemandDao
{
    public MdmDemandDao(ISqlMapper mapper)
    {
        Mapper = mapper;
    }

    private ISqlMapper Mapper { get; }

    public IEnumerable<MdmDemand> GetAll(MdmDemand mdmDemand)
    {
        return Mapper.QueryForList<MdmDemand>("MdmDemand.Select", mdmDemand);
    }

    public void Insert(MdmDemand mdmDemand)
    {
        Mapper.Insert("MdmDemand.Insert", mdmDemand);
    }

    public int Update(MdmDemand mdmDemand)
    {
        return Mapper.Update("MdmDemand.Update", mdmDemand);
    }

    public int Delete(MdmDemand mdmDemand)
    {
        return Mapper.Delete("MdmDemand.Delete", mdmDemand);
    }

    /**
     *  DEMAND PROP
     */
    public IEnumerable<MdmDemandProp> GetAllProp(MdmDemandProp mdmDemandProp)
    {
        return Mapper.QueryForList<MdmDemandProp>("MdmDemandProp.Select", mdmDemandProp);
    }

    public void InsertProp(MdmDemandProp mdmDemandProp)
    {
        Mapper.Insert("MdmDemandProp.InsertProp", mdmDemandProp);
    }

    public int UpdateProp(MdmDemandProp mdmDemandProp)
    {
        return Mapper.Update("MdmDemandProp.Update", mdmDemandProp);
    }

    public int DeleteProp(MdmDemandProp mdmDemandProp)
    {
        return Mapper.Delete("MdmDemandProp.Delete", mdmDemandProp);
    }
}