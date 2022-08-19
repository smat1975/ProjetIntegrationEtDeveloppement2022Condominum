﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace CondominiumManagement.Services
{
    public class NullMailService : IMailService
    {

        private readonly ILogger<NullMailService> _logger;


        public NullMailService(ILogger<NullMailService> logger)
        {
            _logger = logger;
        }

        public ILogger<NullMailService> Logger { get; }

        public void EnvoyerEmail(string destinataire, string titreEmail, string corpsEmail)
        {

            //Logging du mail
            _logger.LogInformation($"Destinataire: {destinataire} Sujet: {titreEmail} Contenu: {corpsEmail}");

        }

    }
}
