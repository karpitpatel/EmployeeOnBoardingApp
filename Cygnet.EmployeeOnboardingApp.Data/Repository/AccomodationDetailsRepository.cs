﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cygnet.EmployeeOnboardingApp.Core.Data.Repository;
using Cygnet.EmployeeOnboardingApp.Data.Model;

namespace Cygnet.EmployeeOnboardingApp.Data.Repository
{
    public interface IAccomodationDetailsRepository : IRepository<AccomodationDetails>
    {
        AccomodationDetails GetAccomodationDetails(int UserId);
        ICollection<AccomodationDetails> GetAccomodationDetails();
        void IsRegisterr(AccomodationDetails model);
        void IsUpdatee(AccomodationDetails model);
    }
    public class AccomodationDetailsRepository : BaseRepository<AccomodationDetails>, IAccomodationDetailsRepository
    {
        public AccomodationDetailsRepository(IEmployeeOnBoardingUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }
        public AccomodationDetails GetAccomodationDetails(int UserId)
        {
            return Get(_ => _.UserId == UserId).FirstOrDefault();
        }
        public ICollection<AccomodationDetails> GetAccomodationDetails()
        {
            return Get().ToList();
        }
        public void IsRegisterr(AccomodationDetails model)
        {
            Insert(model);
        }
        public void IsUpdatee(AccomodationDetails model)
        {
            Update(model);
        }
    }
}
