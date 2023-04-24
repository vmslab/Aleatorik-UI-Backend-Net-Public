using AleatorikUI.Services.DTO.mdm;

namespace AleatorikUI.Services.DAO.mdm;

public interface IMdmOperResDao
{
    public IEnumerable<MdmOperRes> GetAll(MdmOperRes mdmOperRes);
    public void Insert(MdmOperRes mdmOperRes);
    public int Update(MdmOperRes mdmOperRes);
    public int Delete(MdmOperRes mdmOperRes);

    public IEnumerable<MdmOperResProp> GetAllProp(MdmOperResProp mdmOperResProp);
    public void InsertProp(MdmOperResProp mdmOperResProp);
    public int UpdateProp(MdmOperResProp mdmOperResProp);
    public int DeleteProp(MdmOperResProp mdmOperResProp);

    public IEnumerable<MdmOperAddRes> GetAllAddRes(MdmOperAddRes mdmOperAddRes);
    public void InsertAddRes(MdmOperAddRes mdmOperAddRes);
    public int UpdateAddRes(MdmOperAddRes mdmOperAddRes);
    public int DeleteAddRes(MdmOperAddRes mdmOperAddRes);

    public IEnumerable<MdmOperAddResProp> GetAllAddResProp(MdmOperAddResProp mdmOperAddResProp);
    public void InsertAddResProp(MdmOperAddResProp mdmOperAddResProp);
    public int UpdateAddResProp(MdmOperAddResProp mdmOperAddResProp);
    public int DeleteAddResProp(MdmOperAddResProp mdmOperAddResProp);
}
