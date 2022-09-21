using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;

namespace TrialsSystem.IdentityService.Domain.Mappers
{
    /// <summary>
    /// Extension methods to map to/from entity/model for identity resources.
    /// </summary>
    public static class IdentityResourceMappers
    {
        static IdentityResourceMappers()
        {
            Mapper = new MapperConfiguration(cfg => cfg.AddProfile<IdentityResourceMapperProfile>())
                .CreateMapper();
        }

        internal static IMapper Mapper { get; }

        /// <summary>
        /// Maps an entity to a model.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public static IdentityServer4.Models.IdentityResource ToModel(this Entities.IdentityResourceEntity entity)
        {
            return entity == null ? null : Mapper.Map<IdentityServer4.Models.IdentityResource>(entity);
        }

        /// <summary>
        /// Maps a model to an entity.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public static Entities.IdentityResourceEntity ToEntity(this IdentityServer4.Models.IdentityResource model)
        {
            return model == null ? null : Mapper.Map<Entities.IdentityResourceEntity>(model);
        }
    }
}