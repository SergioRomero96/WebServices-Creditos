using Com.Creditos.Domain;
using Com.Creditos.Repository;
using Com.Creditos.Repository.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Creditos.Facade
{
    public class CreditoFacade : IDisposable
    {
        private readonly ICreditoRepository _creditoRepository;

        public CreditoFacade()
        {
            _creditoRepository = new CreditoRepository();
        }

        public IEnumerable<Credito> GetCreditos()
        {
            return _creditoRepository.GetAll();
        }

        public Credito GetCredito(int id)
        {
            return _creditoRepository.GetById(id);
        }

        public Credito Save(Credito credito)
        {
            return _creditoRepository.Add(credito);
        }

        public Credito Update(Credito credito)
        {
            return _creditoRepository.Update(credito);
        }

        public bool Delete(int id)
        {
            return _creditoRepository.Delete(id);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
