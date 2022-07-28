using System;
using Volo.Abp;
using Volo.Abp.Domain.Entities;
using Volo.Abp.MultiTenancy;

namespace ApenHis.Entities
{
    public partial class Feature : Entity<Guid>, ISoftDelete, IMultiTenant,IHasConcurrencyStamp
    {
        public Guid? ParentGuid { get; set; }
        public string Title { get; set; }

        /// <summary>
        /// 是否是菜单
        /// <para>如果是false，则为功能点</para>
        /// </summary>
        public bool IsMenu { get; set; }

        /// <summary>
        /// 图片路径
        /// </summary>
        public string PicUrl { get; set; }

        /// <summary>
        /// dom元素
        /// </summary>
        public string DOM { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpdateTime { get; set; }

        public int? SortNo { get; set; }

        /// <summary>
        /// 是否是根结点
        /// </summary>
        public bool IsRoot { get; set; }

        /// <summary>
        /// 是否隐藏
        /// </summary>
        public bool IsHidden { get; set; }

        /// <summary>
        /// 请求地址
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 是否记录调用日志
        /// </summary>
        public bool IsLog { get; set; }

        public virtual DateTime CreationTime { get; set; }

        /// <summary>
        /// 删除
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Memo { get; set; }

        /// <summary>
        /// 租户ID
        /// </summary>
        public Guid? TenantId { get; set; }

        /// <summary>
        /// 是否是移动端功能
        /// </summary>
        public bool IsMobile { get; set; }
        public string ConcurrencyStamp { get; set; }
    }
}
