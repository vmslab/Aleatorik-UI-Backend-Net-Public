using AleatorikUI.Services.DTO.mdm;

namespace AleatorikUI.Services.DAO.mdm;

public interface IMdmBomRoutingMasterDao
{
    public IEnumerable<MdmBomRoutingMaster> GetAll();
    public void Insert(MdmBomRoutingMaster mdmBomRoutingMaster);
    public int Update(MdmBomRoutingMaster mdmBomRoutingMaster);
    public int Delete(MdmBomRoutingMaster mdmBomRoutingMaster);

    public IEnumerable<MdmBomRoutingSub1> GetAllSub1(String bomID);
    public void InsertSub1(MdmBomRoutingSub1 mdmBomRoutingSub1);
    public int UpdateSub1(MdmBomRoutingSub1 mdmBomRoutingSub1);
    public int DeleteSub1(MdmBomRoutingSub1 mdmBomRoutingSub1);
}
