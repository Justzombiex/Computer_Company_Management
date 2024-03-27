using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CCM.Domain.Entities.Persons;

namespace CCM.DataAccess.FluentConfigurations
{
    /// <summary>
    /// Define las configuraciones de un <see cref="EnterpriseClient"/> para EntityFramework.
    /// </summary> 
    internal class EnterpriseClientFluentConfiguration : IEntityTypeConfiguration<EnterpriseClient>
    {
        public void Configure(EntityTypeBuilder<EnterpriseClient> builder)
        {
            builder.ToTable("EnterpriseClients");
            builder.HasBaseType<Client>();
        }
    }

}