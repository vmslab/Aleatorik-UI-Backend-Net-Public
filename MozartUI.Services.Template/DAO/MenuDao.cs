using MozartUI.Services.Template.DTO;
using SqlBatis.DataMapper;

namespace MozartUI.Services.Template.DAO
{
    public class MenuDao : IMenuDao
    {
        public MenuDao(ISqlMapper mapper)
        {
            Mapper = mapper;
        }

        private ISqlMapper Mapper { get; }

        public IEnumerable<MenuInfo> GetAll(string systemId)
        {
            return Mapper.QueryForList<MenuInfo>("Menu.SelectMenus", systemId);
        }

        public IEnumerable<MenuInfo> GetAll(UserInfo userInfo)
        {
            return Mapper.QueryForList<MenuInfo>("Menu.SelectMenusForUser", userInfo);
        }

        public MenuInfo GetById(MenuInfo menuInfo)
        {
            return Mapper.QueryForObject<MenuInfo>("Menu.SelectMenu", menuInfo.MenuId);
        }

		public int Save(List<MenuInfo> menuInfos)
        {
            var transaction = Mapper.BeginTransaction();
            try
            {
                var affectedRow = 0;
                foreach (var menuInfo in menuInfos)
                {
                    affectedRow += transaction.SqlMapper.Update("Menu.MergeMenu", menuInfo);
                }
                transaction.CommitTransaction();
                return affectedRow;
            } catch (Exception e) {
                transaction.RollBackTransaction();
                throw e;
			}
            return 0;
        }
	}
}
