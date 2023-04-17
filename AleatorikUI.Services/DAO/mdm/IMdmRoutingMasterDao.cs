using AleatorikUI.Services.DTO.mdm;

namespace AleatorikUI.Services.DAO.mdm;

public interface IMdmRoutingMasterDao
{

    public IEnumerable<MdmRoutingMaster> GetAll();
    public void Insert(MdmRoutingMaster mdmRoutingMaster);
    public int Update(MdmRoutingMaster mdmRoutingMaster);
    public int Delete(MdmRoutingMaster mdmRoutingMaster);

    public IEnumerable<MdmRoutingSub1> GetAllSub1(String routingID);
    public void InsertSub1(MdmRoutingSub1 mdmRoutingSub1);
    public int UpdateSub1(MdmRoutingSub1 mdmRoutingSub1);
    public int DeleteSub1(MdmRoutingSub1 mdmRoutingSub1);

    public IEnumerable<MdmRoutingSub2> GetAllSub2(String routingID);
    public void InsertSub2(MdmRoutingSub2 mdmRoutingSub2);
    public int UpdateSub2(MdmRoutingSub2 mdmRoutingSub2);
    public int DeleteSub2(MdmRoutingSub2 mdmRoutingSub2);
}
