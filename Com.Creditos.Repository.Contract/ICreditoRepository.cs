using Com.Creditos.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Creditos.Repository.Contract
{
    public interface ICreditoRepository
    {
        IEnumerable<Credito> GetAll();
        Credito Save(Credito credito);
        Credito Update(Credito credito);
        bool Delete(int id);
    }
}
