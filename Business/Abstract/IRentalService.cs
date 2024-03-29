﻿using Core.Utilities.Result;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IResult Add(Rental rental);
        IResult Update(Rental rental);
        IResult Delete(Rental rental);
        IDataResult<List<Rental>> GetAll();
        IDataResult<Rental> GetById(int id);
        IDataResult<List<RentalDto>> GetRentalDetails();
        IResult RulesForAdding(Rental rental);
        IResult FindexScoreCheck(int customerId,int carId);
        IResult IsRentable(int carId);
        IResult CarIsReturned(int carId);

    }
}
