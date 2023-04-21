using AleatorikUI.Services.DTO.mdm;

namespace AleatorikUI.Services.DAO.mdm
{
    public interface IMdmBomMasterDao
    {
        public IEnumerable<MdmBomMaster> GetAll(MdmBomMaster mdmBomMaster);
        public void Insert(MdmBomMaster mdmBomMaster);
        public int Update(MdmBomMaster mdmBomMaster);
        public int Delete(MdmBomMaster mdmBomMaster);

        public IEnumerable<MdmBomDetail> GetAllDetail(MdmBomDetail mdmBomDetail);
        public void InsertDetail(MdmBomDetail mdmBomDetail);
        public int UpdateDetail(MdmBomDetail mdmBomDetail);
        public int DeleteDetail(MdmBomDetail mdmBomDetail);

        public IEnumerable<MdmBomDetailAlt> GetAllDetailAlt(MdmBomDetailAlt mdmBomDetailAlt);
        public void InsertDetailAlt(MdmBomDetailAlt mdmBomDetailAlt);
        public int UpdateDetailAlt(MdmBomDetailAlt mdmBomDetailAlt);
        public int DeleteDetailAlt(MdmBomDetailAlt mdmBomDetailAlt);

        public IEnumerable<MdmBomProp> GetAllProp(MdmBomProp mdmBomProp);
        public void InsertProp(MdmBomProp mdmBomProp);
        public int UpdateProp(MdmBomProp mdmBomProp);
        public int DeleteProp(MdmBomProp mdmBomProp);

        public IEnumerable<MdmBomRouting> GetAllRouting(MdmBomRouting mdmBomRouting);
        public void InsertRouting(MdmBomRouting mdmBomRouting);
        public int UpdateRouting(MdmBomRouting mdmBomRouting);
        public int DeleteRouting(MdmBomRouting mdmBomRouting);

        public IEnumerable<MdmBomRoutingProp> GetAllRoutingProp(MdmBomRoutingProp mdmBomRoutingProp);
        public void InsertRoutingProp(MdmBomRoutingProp mdmBomRoutingProp);
        public int UpdateRoutingProp(MdmBomRoutingProp mdmBomRoutingProp);
        public int DeleteRoutingProp(MdmBomRoutingProp mdmBomRoutingProp);
    }
}