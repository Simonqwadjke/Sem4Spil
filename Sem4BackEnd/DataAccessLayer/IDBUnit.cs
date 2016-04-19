﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer;

namespace DataAccessLayer
{
    public interface IDBUnit
    {
        bool GetUserUnits(User user);
        bool SaveUserUnits(User user);
    }
}
