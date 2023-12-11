namespace FileAPI.Entity
{
    public class FileEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public long Size { get; set; }
        public string FullPath { get; set; }
    }
}
