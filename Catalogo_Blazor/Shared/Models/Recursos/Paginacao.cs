﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Catalogo_Blazor.Shared.Models.Recursos
{
    public class Paginacao
    {
        public int paginaAtual { get; set; } = 1;
        public int quantidadePorPagina { get; set; } = 5;
    }
}
