﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Cygnet.EmployeeOnboardingApp.Data.Repository;
using Cygnet.EmployeeOnboardingApp.Domain.ViewMapping;
using Cygnet.EmployeeOnboardingApp.Domain.ViewModel;

namespace Cygnet.EmployeeOnboardingApp.Domain.Manager
{
    public interface IAdditionalDetailsManager
    {
        List<AdditionalDetailsViewModel> GetAllAdditionalDetails();
        AdditionalDetailsViewModel GetAdditionalDetails(int UserId);
        void IsRegister(AdditionalDetailsViewModel additionalDetailsViewModel);
        void IsUpdate(AdditionalDetailsViewModel additionalDetailsViewModel);
    }
    public class AdditionalDetailsManager : BaseManager, IAdditionalDetailsManager
    {
        private readonly IAdditionalDetailsRepository _additionalDetailsRepository;
        private AdditionalDetailsMapping additionalDetailsMapping;

        public AdditionalDetailsManager(IAdditionalDetailsRepository additionalDetailsRepository)
        {
            _additionalDetailsRepository = additionalDetailsRepository;
            additionalDetailsMapping = new AdditionalDetailsMapping();

        }
        public List<AdditionalDetailsViewModel> GetAllAdditionalDetails()
        {
            var dataModelList = _additionalDetailsRepository.GetAdditionalDetails();
            return additionalDetailsMapping.MapToViewList(dataModelList);

        }
        public AdditionalDetailsViewModel GetAdditionalDetails(int UserId)
        {
            var dataModel = _additionalDetailsRepository.GetAdditionalDetails(UserId);
            return additionalDetailsMapping.MapToView(dataModel);

        }
        public void IsRegister(AdditionalDetailsViewModel additionalDetailsViewModel)
        {
            _additionalDetailsRepository.IsRegisterr(additionalDetailsMapping.MapToModel(additionalDetailsViewModel));
            _additionalDetailsRepository.UnitOfWork.Save();

        }
        public void IsUpdate(AdditionalDetailsViewModel additionalDetailsViewModel)
        {
            _additionalDetailsRepository.IsUpdatee(additionalDetailsMapping.MapToModel(additionalDetailsViewModel));
            _additionalDetailsRepository.UnitOfWork.Save();

        }
    }
}

