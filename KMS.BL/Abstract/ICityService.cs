using KMS.Model;
using System.Collections.Generic;

namespace KMS.BL
{
    /// <summary>
    /// This is the interface of City
    /// </summary>
    public interface ICityService
    {
        int Save(City model);
        List<City> GetCity();
    }
}
