﻿using AleatorikUI.Services.DTO.mdm;

namespace AleatorikUI.Services.DAO.mdm
{
    public interface IMdmSiteDao
    {
        public IEnumerable<MdmSite> GetAll();
        public MdmSite GetById(string mdmSite);
        public void Insert(MdmSite mdmSite);
        public int Update(MdmSite mdmSite);
        public int Delete(MdmSite mdmSite);
    }
}