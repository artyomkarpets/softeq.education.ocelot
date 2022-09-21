using AutoMapper;

namespace TrialsSystem.IdentityService.Domain.Mappers
{
    /// <summary>
    /// Extension methods to map to/from entity/model for API resources.
    /// </summary>
    public static class ApiResourceMappers
    {
        static ApiResourceMappers()
        {
            Mapper = new MapperConfiguration(cfg => cfg.AddProfile<ApiResourceMapperProfile>())
                .CreateMapper();
        }

        internal static IMapper Mapper { get; }

        /// <summary>
        /// Maps an entity to a model.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public static IdentityServer4.Models.ApiResource ToModel(this Entities.ApiResourceEntity entity)
        {
            return entity == null ? null : Mapper.Map<IdentityServer4.Models.ApiResource>(entity);
        }

        /// <summary>
        /// Maps a model to an entity.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public static Entities.ApiResourceEntity ToEntity(this IdentityServer4.Models.ApiResource model)
        {
            return model == null ? null : Mapper.Map<Entities.ApiResourceEntity>(model);
        }

        /// <summary>
        /// Maps an entity to a model.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public static IdentityServer4.Models.ApiScope ToModel(this Entities.ApiScopeEntity entity)
        {
            return entity == null ? null : Mapper.Map<IdentityServer4.Models.ApiScope>(entity);
        }

        /// <summary>
        /// Maps a model to an entity.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public static Entities.ApiScopeEntity ToEntity(this IdentityServer4.Models.ApiScope model)
        {
            return model == null ? null : Mapper.Map<Entities.ApiScopeEntity>(model);
        }
    }
}