using MozartUI.Services.Template.DTO;
using SqlBatis.DataMapper;

namespace MozartUI.Services.Template.DAO
{
    public class GroupDao : IGroupDao
    {
        public GroupDao(ISqlMapper mapper)
        {
            Mapper = mapper;
        }

        private ISqlMapper Mapper { get; }

        public IEnumerable<GroupInfo> GetAll()
        {
            return Mapper.QueryForList<GroupInfo>("Group.SelectGroups", null);
        }

        public GroupInfo GetById(GroupInfo groupInfo)
        {
            return Mapper.QueryForObject<GroupInfo>("Group.SelectGroup", groupInfo.GroupId);
        }

        public IEnumerable<GroupInfo> GetBySystem(GroupInfo groupInfo)
        {
            return Mapper.QueryForList<GroupInfo>("Group.SelectGroupsBySystem", groupInfo.SystemId);
        }

        public void Insert(GroupInfo groupInfo)
        {
            Mapper.Insert("Group.InsertGroup", groupInfo);
        }

		public int Update(GroupInfo groupInfo)
        {
            return Mapper.Update("Group.UpdateGroup", groupInfo);
        }

		public int Delete(GroupInfo groupInfo)
		{
            return Mapper.Delete("Group.DeleteGroup", groupInfo.GroupId);
		}
	}
}
