﻿using EntityLayer.Information_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository_Interfaces.Information_Interfaces
{
    public interface IRepositoryIntern : IRepository<InternCompany>
    {
        void RemoveAll(int studentID);
    }
}
