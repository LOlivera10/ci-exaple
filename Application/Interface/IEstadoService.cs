﻿using Application.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    internal interface IEstadoService
    {
        public Response findOneEstado(int description);
    }
}