using AleatorikUI.Services.DTO.mdm;

namespace AleatorikUI.Services.DAO.mdm;

public interface IMdmRoutingMasterDao
{
    public IEnumerable<MdmRoutingMaster> GetAll();
    public void Insert(MdmRoutingMaster mdmRoutingMaster);
    public int Update(MdmRoutingMaster mdmRoutingMaster);
    public int Delete(MdmRoutingMaster mdmRoutingMaster);

    public IEnumerable<MdmRoutingOper> GetAllSub1(String routingID);
    public void InsertSub1(MdmRoutingOper mdmRoutingSub1);
    public int UpdateSub1(MdmRoutingOper mdmRoutingSub1);
    public int DeleteSub1(MdmRoutingOper mdmRoutingSub1);

    public IEnumerable<MdmRoutingOperProp> GetAllSub2(String routingID);
    public void InsertSub2(MdmRoutingOperProp mdmRoutingSub2);
    public int UpdateSub2(MdmRoutingOperProp mdmRoutingSub2);
    public int DeleteSub2(MdmRoutingOperProp mdmRoutingSub2);
}
