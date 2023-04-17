using AleatorikUI.Services.DTO.mdm;

namespace AleatorikUI.Services.DAO.mdm
{
    public interface IMdmBomMasterDao
    {
        public IEnumerable<MdmBomMaster> GetAll();
        public void Insert(MdmBomMaster mdmBomMaster);
        public int Update(MdmBomMaster mdmBomMaster);
        public int Delete(MdmBomMaster mdmBomMaster);

        public IEnumerable<MdmBomSub1> GetAllSub1(String bomID);
        public void InsertSub1(MdmBomSub1 mdmBomSub1);
        public int UpdateSub1(MdmBomSub1 mdmBomSub1);
        public int DeleteSub1(MdmBomSub1 mdmBomSub1);

        public IEnumerable<MdmBomSub2> GetAllSub2(String bomID);
        public void InsertSub2(MdmBomSub2 mdmBomSub2);
        public int UpdateSub2(MdmBomSub2 mdmBomSub2);
        public int DeleteSub2(MdmBomSub2 mdmBomSub2);

        public IEnumerable<MdmBomSub3> GetAllSub3(String bomID);
        public void InsertSub3(MdmBomSub3 mdmBomSub3);
        public int UpdateSub3(MdmBomSub3 mdmBomSub3);
        public int DeleteSub3(MdmBomSub3 mdmBomSub3);

        public IEnumerable<MdmBomSub4> GetAllSub4(String bomID);
        public void InsertSub4(MdmBomSub4 mdmBomSub4);
        public int UpdateSub4(MdmBomSub4 mdmBomSub4);
        public int DeleteSub4(MdmBomSub4 mdmBomSub4);

        public IEnumerable<MdmBomSub5> GetAllSub5(String bomID);
        public void InsertSub5(MdmBomSub5 mdmBomSub5);
        public int UpdateSub5(MdmBomSub5 mdmBomSub5);
        public int DeleteSub5(MdmBomSub5 mdmBomSub5);
    }
}