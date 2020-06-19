﻿using ioliu.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ioliu.web.Sercers
{
    public interface IResumeServers<T> where T:class
    {
         SystemUser GetById(int id);
         IEnumerable<T> GetAll();

         SystemUser Add(T newModel);

    }
}
