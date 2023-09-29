using Core.DataAccess.EntityFramework;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal :EfEntityRepositoryBase<Car,ReCapContext>,ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (ReCapContext context=new ReCapContext())
            {
                var result = from car in context.Cars
                             join brand in context.Brands on car.BrandId equals brand.Id
                             join color in context.Colors on car.ColorId equals color.Id
                             join carImage in context.CarImages on car.CarId equals carImage.CarId
                             select new CarDetailDto
                             {
                                 CarId = car.CarId,
                                 CarName = car.CarName,
                                 ModelYear = car.ModelYear,
                                 DailyPrice = car.DailyPrice,
                                 Description = car.Description,
                                 CarImage=carImage.ImagePath,
                                 BrandName = brand.Name,
                                 ColorName = color.Name,
                             };
                return result.ToList();
                             
            }   
        }

        public List<CarDetailDto> GetCarDetailsByBrandId(int brandId)
        {
            using(ReCapContext context=new ReCapContext())
            {
                var result = from car in context.Cars
                             join color in context.Colors on car.ColorId equals color.Id
                             join brand in context.Brands on car.BrandId equals brand.Id
                             join carImage in context.CarImages on car.CarId equals carImage.CarId
                             where brand.Id == brandId
                             select new CarDetailDto()
                             {
                                 CarId = car.CarId,
                                 CarName = car.CarName,
                                 ColorName = color.Name,
                                 BrandName = brand.Name,
                                 DailyPrice = car.DailyPrice,
                                 CarImage = carImage.ImagePath,
                                 Description = car.Description,
                                 ModelYear = car.ModelYear

                             };
                return result.ToList();
            }
            
        }

        public List<CarDetailDto> GetCarDetailsByColorId(int colorId)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from car in context.Cars
                             join color in context.Colors on car.ColorId equals color.Id
                             join brand in context.Brands on car.BrandId equals brand.Id
                             join carImage in context.CarImages on car.CarId equals carImage.CarId
                             where color.Id == colorId
                             select new CarDetailDto()
                             {
                                 CarId = car.CarId,
                                 CarName = car.CarName,
                                 ColorName = color.Name,
                                 BrandName = brand.Name,
                                 CarImage= carImage.ImagePath,
                                 DailyPrice = car.DailyPrice,
                                 Description = car.Description,
                                 ModelYear = car.ModelYear
                             };
                return result.ToList();

            }

        }

        

        public List<CarDetailDto> GetCarDetailsByBrandAndColor(int brandId, int colorId)
        {

            using(ReCapContext context = new ReCapContext())
            {
                var result = from car in context.Cars
                             join brand in context.Brands on car.BrandId equals brand.Id
                             join color in context.Colors on car.ColorId equals color.Id
                             join carImage in context.CarImages on car.CarId equals carImage.CarId
                             where car.BrandId == brandId && car.ColorId == colorId
                             select new CarDetailDto()
                             {
                                 CarId = car.CarId,
                                 CarName = car.CarName,
                                 ColorName = color.Name,
                                 BrandName = brand.Name,
                                 CarImage = carImage.ImagePath,
                                 DailyPrice = car.DailyPrice,
                                 Description = car.Description,
                                 ModelYear = car.ModelYear
                             };

                return result.ToList();
            }





            
        }





        
                           
                
            




    }
}
