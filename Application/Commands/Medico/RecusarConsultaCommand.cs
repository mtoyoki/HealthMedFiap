﻿namespace Application.Commands.Medico
{
    public class RecusarConsultaCommand
    {
        public string Crm { get; set; }
        public int ConsultaMedicaId { get; set; }
        public bool DisponibilizarAgenda { get; set; }
    }
}
