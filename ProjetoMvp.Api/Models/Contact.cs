﻿using Flunt.Notifications;
using Flunt.Validations;
using System;

namespace ProjetoMvp.Api.Models
{
    public class Contact : Notifiable
    {
        public Guid Id { get; private set; }
        public Email Email { get; private set; }
        public Phone Phone { get; private set; }
        public Phone WhatsApp { get; private set; }
        public string Facebook { get; private set; }
        public string Twitter { get; private set; }
        public string Instagram { get; private set; }

        public Contact(Email email, Phone phone)
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNull(email, nameof(Email), "E-mail não pode ser nulo.")
                .IsNotNull(phone, nameof(Phone), "Telefone não pode ser nulo.")
            );

            if (Valid)
            {
                Id = Guid.NewGuid();
                Email = email;
                Phone = phone;
            }
        }
    }
}
