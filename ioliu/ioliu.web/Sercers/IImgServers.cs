using ioliu.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ioliu.web.Sercers
{
    public interface IImgServers<T> where T :class
    {
        Task<Img> AddImg(T newModel);
       IEnumerable< Img> GetImgAll();
        Img GetImgID(string id);
        IEnumerable<Img> GetImgGroup(string GroupName);
    }
}
