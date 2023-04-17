using AleatorikUI.Services.DTO.sam;

namespace AleatorikUI.Services.DAO.sam;

public interface ISamGroupDao
{
    public IEnumerable<SamGroupInfo> GetAll();
    public SamGroupInfo GetById(SamGroupInfo samGroupInfo);
    public IEnumerable<SamGroupInfo> GetBySystem(string systemId);
    public void Insert(SamGroupInfo samGroupInfo);
    public int Update(SamGroupInfo samGroupInfo);
    public int Delete(SamGroupInfo samGroupInfo);
}
