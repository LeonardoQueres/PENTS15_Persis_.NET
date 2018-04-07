﻿using AutoMapper;
using System;

namespace Shared.Conversores
{
    // Automapper string to bool
    public class StringToBooleanTypeConverter : ITypeConverter<string, bool>
    {
        public bool Convert(string source, bool destination, ResolutionContext context)
        {
            if (source == null)
                throw new ArgumentNullException(Textos.Shared_Mensagem_Erro_String_To_Boolean);
            else
                return Boolean.Parse(source);
        }
    }
}
