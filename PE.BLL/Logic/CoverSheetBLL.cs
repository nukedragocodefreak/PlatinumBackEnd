using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PE.BO.Models.Request;
using PE.BO.Models.Response;
using PE.DAL.Repositories;
using PE.DAL.Repository;

namespace PE.BLL.Logic
{
    public class CoverSheetBLL : ICoverSheetBLL
    {
        private readonly ICoverSheetRepository _coverSheetRepository;
        public CoverSheetBLL(ICoverSheetRepository coverSheetRepository)
        {
            _coverSheetRepository = coverSheetRepository;
        }

        public async Task<IEnumerable<CoverSheet>> GetCoverSheet()
        {
            var saveResponse = await _coverSheetRepository.GetCoverSheet();
            return saveResponse;
        }

        public async Task<ApiGenericResponse> SaveCoverSheet(CoverSheet coverSheet)
        {
            var saveResponse = await _coverSheetRepository.SaveCoverSheet(coverSheet);
            return saveResponse;
        }
    }
}
