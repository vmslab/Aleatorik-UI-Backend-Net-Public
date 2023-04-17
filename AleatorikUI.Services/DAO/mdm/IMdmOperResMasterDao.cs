using AleatorikUI.Services.DTO.mdm;

namespace AleatorikUI.Services.DAO.mdm;

public interface IMdmOperResMasterDao
{
    public IEnumerable<MdmOperResMaster> GetAll();
    public void Insert(MdmOperResMaster mdmOperResMaster);
    public int Update(MdmOperResMaster mdmOperResMaster);
    public int Delete(MdmOperResMaster mdmOperResMaster);

    public IEnumerable<MdmOperResSub1> GetAllSub1(String routingID);
    public void InsertSub1(MdmOperResSub1 mdmOperResSub1);
    public int UpdateSub1(MdmOperResSub1 mdmOperResSub1);
    public int DeleteSub1(MdmOperResSub1 mdmOperResSub1);
}
