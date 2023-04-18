using AleatorikUI.Services.DTO.mdm;

namespace AleatorikUI.Services.DAO.mdm
{
    public interface IMdmCalMasterDao
    {
        public IEnumerable<MdmCalMaster> GetAll();
        public void Insert(MdmCalMaster mdmCalMaster);
        public int Update(MdmCalMaster mdmCalMaster);
        public int Delete(MdmCalMaster mdmCalMaster);

        public IEnumerable<MdmCalSub1> GetAllSub1(String calendarID);
        public void InsertSub1(MdmCalSub1 mdmCalSub1);
        public int UpdateSub1(MdmCalSub1 mdmCalSub1);
        public int DeleteSub1(MdmCalSub1 mdmCalSub1);

        public IEnumerable<MdmCalSub2> GetAllSub2(String calendarID);
        public void InsertSub2(MdmCalSub2 mdmCalSub2);
        public int UpdateSub2(MdmCalSub2 mdmCalSub2);
        public int DeleteSub2(MdmCalSub2 mdmCalSub2);
    }
}