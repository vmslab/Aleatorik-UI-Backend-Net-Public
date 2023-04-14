using AleatorikUI.Services.DTO.mdm;

namespace AleatorikUI.Services.DAO.mdm
{
    public interface IMdmBomDao
    {
        public IEnumerable<MdmBom> GetAll();
        public void Insert(MdmBom mdmBom);
        public int Update(MdmBom mdmBom);
        public int Delete(MdmBom mdmBom);

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
    }
}