﻿// Project: Aguafrommars/TheIdServer
// Copyright (c) 2020 @Olivier Lefebvre
using Aguacongas.IdentityServer.Store.Entity;
using FluentValidation;

namespace Aguacongas.TheIdServer.BlazorApp.Validators
{
    public class ClientRedirectUriValidator : AbstractValidator<ClientUri>
    {
        public ClientRedirectUriValidator(Client client)
        {
            RuleFor(m => m.Uri).MaximumLength(2000).WithMessage("An url cannot exceed 2000 char.");
            RuleFor(m => m.Uri).Uri().WithMessage((c, v) => $"The url '{v}' is not valid.");
            RuleFor(m => m.Uri).IsUnique(client.RedirectUris).WithMessage("Uri must be unique.");
        }
    }
}
