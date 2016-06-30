using CarmaCore.Pix;
using System.Collections.Generic;

namespace CarmaCore.Contracts
{
    public interface IPixService
    {
        IList<PixDTO> GetAllPixData();
    }
}
