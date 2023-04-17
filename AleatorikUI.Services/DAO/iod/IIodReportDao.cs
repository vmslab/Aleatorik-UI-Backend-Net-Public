using AleatorikUI.Services.DTO.iod;

namespace AleatorikUI.Services.DAO.iod
{
    public interface IRarBomMapViewDao
    {
        public IEnumerable<RarBomMapView> GetAll();
        public void Insert(RarBomMapView iodReport);
        public int Update(RarBomMapView iodReport);
        public int Delete(RarBomMapView iodReport);
    }
}