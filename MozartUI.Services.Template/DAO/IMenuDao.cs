﻿using MozartUI.Services.Template.DTO;

namespace MozartUI.Services.Template.DAO
{
    public interface IMenuDao
    {
        public IEnumerable<MenuInfo> GetAll(string systemId);
        public IEnumerable<MenuInfo> GetAll(UserInfo userInfo);
        public MenuInfo GetById(MenuInfo menuInfo);
        public int Save(List<MenuInfo> menuInfos);
    }
}