namespace FileAPI.Dtos
{
    public class FolderDto
    {
        public Guid? ParentId { get; set; }
        public string Name { get; set; }

        public FolderDto(Guid? parentId, string name)
        {
            ParentId = parentId;
            Name = name;
        }
    }
}
