using TeachingAPI.NewFolder;

namespace TeachingAPI.Interfaces
{
    public interface IDarbuotojasService
    {
        public List<Darbuotojas> GetDarbuotojas();

        public int InsertDarbuotojas(Darbuotojas darbuotojas);

        public int ModifyDarbuotojas(Darbuotojas darbuotojas);

    }
}
