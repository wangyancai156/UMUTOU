using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Models.BW;
using WangYc.Services.ViewModels.BW;

namespace WangYc.Services.Mapping.BW {
    public static class InBoundMapper {

        public static InBoundView ConvertToInBoundView(this InOutBound model) {

            return Mapper.Map<InOutBound, InBoundView>(model);
        }

        public static IEnumerable<InBoundView> ConvertToInBoundView(this IEnumerable<InOutBound> model) {

            return Mapper.Map<IEnumerable<InOutBound>, IEnumerable<InBoundView>>(model);
        }
    }
}
