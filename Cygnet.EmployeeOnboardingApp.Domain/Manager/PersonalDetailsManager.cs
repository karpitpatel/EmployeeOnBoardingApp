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
    public interface IPersonalDetailsManager
    {
        List<PersonalDetailsViewModel> GetAllPersonalDetails();
        PersonalDetailsViewModel GetPersonalDetails(int EmpCode);
        void IsRegister(PersonalDetailsViewModel personalDetailsViewModel);
        // void GetpersonalalDetails(int? id);
        void IsUpdate(PersonalDetailsViewModel personalDetailsViewModel);
    }
    public class PersonalDetailsManager : BaseManager, IPersonalDetailsManager
    {
        private readonly IPersonalDetailsRepository _personalDetailsRepository;
        private PersonalDetailsMapping personalDetailsMapping;

        public PersonalDetailsManager(IPersonalDetailsRepository personalDetailsRepository)
        {
            _personalDetailsRepository = personalDetailsRepository;
            personalDetailsMapping = new PersonalDetailsMapping();

        }
        public List<PersonalDetailsViewModel> GetAllPersonalDetails()
        {
            var dataModelList = _personalDetailsRepository.GetPersonalDetails();
            return personalDetailsMapping.MapToViewList(dataModelList);

        }
        public PersonalDetailsViewModel GetPersonalDetails(int EmpCode)
        {
            var dataModel = _personalDetailsRepository.GetPersonalDetails(EmpCode);
            return personalDetailsMapping.MapToView(dataModel);

        }
        public void IsRegister(PersonalDetailsViewModel personalDetailsViewModel)
        {
            _personalDetailsRepository.IsRegisterr(personalDetailsMapping.MapToModel(personalDetailsViewModel));
            _personalDetailsRepository.UnitOfWork.Save();

        }
        public void IsUpdate(PersonalDetailsViewModel personalDetailsViewModel)
        {
            _personalDetailsRepository.IsUpdatee(personalDetailsMapping.MapToModel(personalDetailsViewModel));
            _personalDetailsRepository.UnitOfWork.Save();

        }
    }
}
