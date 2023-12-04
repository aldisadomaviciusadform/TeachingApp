using TeachingAPI.NewFolder;

namespace TeachingAPI.Interfaces
{
    public interface IDarbuotojasRepository
    {
        public IEnumerable<Darbuotojas> GetDarbuotojai();

        public int InsertDarbuotojas(string name, string id, string lastName);

        public int ModifyDarbuotojas(string name, string id, string lastName);
    }
}