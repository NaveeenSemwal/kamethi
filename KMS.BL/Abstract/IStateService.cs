using KMS.Model;
using System.Collections.Generic;

namespace KMS.BL
{
    public interface IStateService
    {
        int Save(State model);
        List<State> GetState();
    }
}
