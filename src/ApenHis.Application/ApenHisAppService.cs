using System;
using System.Collections.Generic;
using System.Text;
using ApenHis.Localization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;

namespace ApenHis;

/* Inherit your application services from this class.
 */
public abstract class ApenHisAppService : ApplicationService
{
    protected ApenHisAppService()
    {
        LocalizationResource = typeof(ApenHisResource);
    }
}

public abstract class ApenHisCrudAppService<TEntity, TEntityDto, TKey, TGetListInput, TCreateInput, TUpdateInput> : CrudAppService<TEntity, TEntityDto, TKey, TGetListInput, TCreateInput, TUpdateInput>
     where TEntity : class, IEntity<TKey>
    where TEntityDto : IEntityDto<TKey>
{
    protected ApenHisCrudAppService(IRepository<TEntity, TKey> repository): base(repository)
    {
        LocalizationResource = typeof(ApenHisResource);
    }
}

public abstract class ApenHisCrudAppService<TEntity, TGetOutputDto, TGetListOutputDto, TKey, TGetListInput, TCreateInput, TUpdateInput> : CrudAppService<TEntity, TGetOutputDto, TGetListOutputDto, TKey, TGetListInput, TCreateInput, TUpdateInput>
      where TEntity : class, IEntity<TKey>
    where TGetOutputDto : IEntityDto<TKey>
    where TGetListOutputDto : IEntityDto<TKey>
{
    protected ApenHisCrudAppService(IRepository<TEntity, TKey> repository) : base(repository)
    {
        LocalizationResource = typeof(ApenHisResource);
    }
}
