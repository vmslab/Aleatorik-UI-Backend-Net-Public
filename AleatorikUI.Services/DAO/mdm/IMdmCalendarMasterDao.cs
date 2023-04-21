using AleatorikUI.Services.DTO.mdm;

namespace AleatorikUI.Services.DAO.mdm
{
    public interface IMdmCalendarMasterDao
    {
        public IEnumerable<MdmCalendarMaster> GetAll(MdmCalendarMaster mdmCalendarMaster);
        public void Insert(MdmCalendarMaster mdmCalendarMaster);
        public int Update(MdmCalendarMaster mdmCalendarMaster);
        public int Delete(MdmCalendarMaster mdmCalendarMaster);

        public IEnumerable<MdmCalendarDetail> GetAllDetail(MdmCalendarDetail mdmCalendarDetail);
        public void InsertDetail(MdmCalendarDetail mdmCalendarDetail);
        public int UpdateDetail(MdmCalendarDetail mdmCalendarDetail);
        public int DeleteDetail(MdmCalendarDetail mdmCalendarDetail);

        public IEnumerable<MdmCalendarBasedAttr> GetAllBasedAttr(MdmCalendarBasedAttr mdmCalendarBasedAttr);
        public void InsertBasedAttr(MdmCalendarBasedAttr mdmCalendarBasedAttr);
        public int UpdateBasedAttr(MdmCalendarBasedAttr mdmCalendarBasedAttr);
        public int DeleteBasedAttr(MdmCalendarBasedAttr mdmCalendarBasedAttr);
    }
}