using AleatorikUI.Services.DTO.mdm;

namespace AleatorikUI.Services.DAO.mdm
{
    public interface IMdmBomMasterDao
    {
        public IEnumerable<MdmBomMaster> GetAll(String projectID);
        public void Insert(MdmBomMaster mdmBomMaster);
        public int Update(MdmBomMaster mdmBomMaster);
        public int Delete(MdmBomMaster mdmBomMaster);

        public IEnumerable<MdmBomDetail> GetAllDetail(String projectID);
        public void InsertDetail(MdmBomDetail mdmBomDetail);
        public int UpdateDetail(MdmBomDetail mdmBomDetail);
        public int DeleteDetail(MdmBomDetail mdmBomDetail);

        public IEnumerable<MdmBomDetailAlt> GetAllDetailAlt(String projectID);
        public void InsertDetailAlt(MdmBomDetailAlt mdmBomDetailAlt);
        public int UpdateDetailAlt(MdmBomDetailAlt mdmBomDetailAlt);
        public int DeleteDetailAlt(MdmBomDetailAlt mdmBomDetailAlt);

        public IEnumerable<MdmBomProp> GetAllProp(String projectID);
        public void InsertProp(MdmBomProp mdmBomProp);
        public int UpdateProp(MdmBomProp mdmBomProp);
        public int DeleteProp(MdmBomProp mdmBomProp);

        public IEnumerable<MdmBomRouting> GetAllRouting(String projectID);
        public void InsertRouting(MdmBomRouting mdmBomRouting);
        public int UpdateRouting(MdmBomRouting mdmBomRouting);
        public int DeleteRouting(MdmBomRouting mdmBomRouting);

        public IEnumerable<MdmBomRoutingProp> GetAllRoutingProp(String projectID);
        public void InsertRoutingProp(MdmBomRoutingProp mdmBomRoutingProp);
        public int UpdateRoutingProp(MdmBomRoutingProp mdmBomRoutingProp);
        public int DeleteRoutingProp(MdmBomRoutingProp mdmBomRoutingProp);
    }
}