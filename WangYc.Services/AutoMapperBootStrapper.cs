using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using WangYc.Models.HR;
using WangYc.Services.ViewModels.HR;
using WangYc.Services.ViewModels;
using WangYc.Models.BW;
using WangYc.Services.ViewModels.BW;
using WangYc.Models.SD;
using WangYc.Services.ViewModels.SD;

namespace WangYc.Services
{
    public static class AutoMapperBootStrapper
    {
        public static void ConfigureAutoMapper() {
            
            #region HR

            Mapper.CreateMap<Organization, OrganizationView>();
            Mapper.CreateMap<Organization, DataTreeView>()
                .ForMember(d => d.id, t => t.MapFrom(s => s.Id))
                .ForMember(d => d.text, t => t.MapFrom(s => s.Name))
                .ForMember(d => d.nodes, t => t.MapFrom(s => s.Child));

            Mapper.CreateMap<Users, UsersView>();
            Mapper.CreateMap<Rights, RightsView>();
            Mapper.CreateMap<Rights, DataTreeView>()
               .ForMember(d => d.id, t => t.MapFrom(s => s.Id))
               .ForMember(d => d.text, t => t.MapFrom(s => s.Name))
               .ForMember(d => d.nodes, t => t.MapFrom(s => s.Child));

            Mapper.CreateMap<Role, RoleView>();

            Mapper.CreateMap<InOutBound, InOutBoundView>();
            #endregion

            #region BW

            Mapper.CreateMap<Warehouse, WarehouseView>();
            Mapper.CreateMap<WarehouseShelf, WarehouseShelfView>();

            Mapper.CreateMap<InOutBound, InOutBoundView>();
            Mapper.CreateMap<OutBound, OutBoundView>();
            Mapper.CreateMap<InBound, InBoundView>();

            Mapper.CreateMap<InOutBoundOfShelf, InOutBoundOfShelfView>();
            Mapper.CreateMap<InBoundOfShelf, InBoundOfShelfView>();
            Mapper.CreateMap<OutBoundOfShelf, OutBoundOfShelfView>();
             
            
            #endregion

            #region SD

            Mapper.CreateMap<Product, ProductView>();
            #endregion
        }
      
    }
}
