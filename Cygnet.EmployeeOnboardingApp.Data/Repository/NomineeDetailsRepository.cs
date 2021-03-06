﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cygnet.EmployeeOnboardingApp.Core.Data.Repository;
using Cygnet.EmployeeOnboardingApp.Data.Model;

namespace Cygnet.EmployeeOnboardingApp.Data.Repository
{
    public interface INomineeDetailsRepository : IRepository<NomineeDetails>
    {
        NomineeDetails GetNomineeDetails(int UserId);
        ICollection<NomineeDetails> GetNomineeDetails();
        void IsRegisterr(NomineeDetails model);
        void IsUpdatee(NomineeDetails model);
    }
    public class NomineeDetailsRepository : BaseRepository<NomineeDetails>, INomineeDetailsRepository
    {
        public NomineeDetailsRepository(IEmployeeOnBoardingUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }
        public NomineeDetails GetNomineeDetails(int UserId)
        {
            return Get(_ => _.UserId == UserId).LastOrDefault();
        }
        public ICollection<NomineeDetails> GetNomineeDetails()
        {
            return Get().ToList();
        }
        public void IsRegisterr(NomineeDetails model)
        {
            Insert(model);
        }
        public void IsUpdatee(NomineeDetails model)
        {
            Update(model);
        }
    }
}
