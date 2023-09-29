using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal:EfEntityRepositoryBase<Rental, ReCapContext>, IRentalDal
    {
        public List<RentalDto> GetRentalDetails()
        {
            using(ReCapContext context=new ReCapContext())
            {
                var result = from rental in context.Rentals
                             join car in context.Cars on rental.CarId equals car.CarId
                             join customer in context.Customers on rental.CustomerId equals customer.Id
                             join brand in context.Brands on car.BrandId equals brand.Id
                             join user in context.Users on customer.UserId equals user.Id
                             join color in context.Colors on car.ColorId equals color.Id
                             select new RentalDto
                             {
                                 RentalId = rental.Id,
                                 BrandName=brand.Name,
                                 ColorName=color.Name,
                                 FullName=$"{user.FirstName} {user.LastName}",
                                 RentDate=rental.RentDate,
                                 ReturnDate=rental.ReturnDate
                             };
                return result.ToList();
            }

            
        }



    }
}
