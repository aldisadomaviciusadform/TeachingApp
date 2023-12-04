using TeachingAPI.Interfaces;
using TeachingAPI.NewFolder;

namespace TeachingAPI.Services
{
    public class DarbuotojaiService : IDarbuotojasService
    {
        private readonly IDarbuotojasRepository _darbuotojasRepository;
        public DarbuotojaiService(IDarbuotojasRepository darbuotojasRepository)
        {
            _darbuotojasRepository = darbuotojasRepository;
        }

        public List<Darbuotojas> GetDarbuotojas()
        {
            return _darbuotojasRepository.GetDarbuotojai().ToList();
        }

        public int InsertDarbuotojas(Darbuotojas darbuotojas)
        {
            return _darbuotojasRepository.InsertDarbuotojas(darbuotojas.Vardas, darbuotojas.AsmensKodas, darbuotojas.Pavarde);
        }

        public int ModifyDarbuotojas(Darbuotojas darbuotojas)
        {
            return _darbuotojasRepository.ModifyDarbuotojas(darbuotojas.Vardas, darbuotojas.AsmensKodas, darbuotojas.Pavarde);
        }
    }
}
