﻿using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public abstract class BaseService
    {
        protected static BasicRepository repository = new BasicRepository();
    }
}
