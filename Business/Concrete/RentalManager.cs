using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Castle.Core.Resource;
using Core.Aspect.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            //ValidationTool.Validate(new RentalValidator(), rental);
            _rentalDal.Add(rental);
                
            return new SuccessResult(Messages.RentalAdded);

        }

        

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(),Messages.RentalListed);
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(x=>x.Id==id));
        }

        public IDataResult<List<RentalDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDto>>(_rentalDal.GetRentalDetails());
        }

        public IResult RulesForAdding(Rental rental)
        {
            var result = BusinessRules.Run(CheckIfThisCarIsAlreadyRentedInSelectedDateRange(rental),
                        CheckIfReturnDateIsBeforeRentDate(rental.ReturnDate,Convert.ToDateTime(rental.RentDate)));

            if(result != null)
            {
                return result;
            }
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.CarRentalAdded);



        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }


        private IResult CheckIfThisCarIsAlreadyRentedInSelectedDateRange(Rental rental)
        {
            var result = _rentalDal.Get(r => r.CarId == rental.CarId && (r.RentDate == rental.RentDate
            || (r.RentDate<rental.RentDate && (r.ReturnDate==null || ((DateTime)r.ReturnDate).Date>rental.ReturnDate))));
            
            if(result != null)
            {
                Console.WriteLine($"r.ReturnDate: {result.ReturnDate}");
                return new ErrorResult(Messages.RentError);
            }
            
            return new SuccessResult();


        }

        private IResult CheckIfReturnDateIsBeforeRentDate(DateTime? returnDate,DateTime rentDate)
        {
            if(returnDate != null)
            {
                if (returnDate < rentDate)
                {
                    return new ErrorResult(Messages.CarAlreadyRented);
                }
            }
            return new SuccessResult();
        }

       
    }
}
