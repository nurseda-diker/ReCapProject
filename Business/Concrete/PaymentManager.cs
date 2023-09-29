using Business.Abstract;
using Business.Constants;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PaymentManager : IPaymentService
    {
        IPaymentDal _paymentDal;
        public PaymentManager(IPaymentDal paymentDal)
        {
            _paymentDal = paymentDal;
        }
        public IResult Add(Payment payment)
        {
            _paymentDal.Add(payment);
            return new SuccessResult();
        }

        public IResult Delete(Payment payment)
        {
            _paymentDal.Delete(payment);
            return new SuccessResult();
        }

        public IDataResult<List<Payment>> GetAll()
        {
            return new SuccessDataResult<List<Payment>>(_paymentDal.GetAll());
        }

        public IDataResult<Payment> GetById(int paymentId)
        {
            return new SuccessDataResult<Payment>(_paymentDal.Get(p => p.Id == paymentId));
        }

        public IResult Pay(Payment payment)
        {
            var result = _paymentDal.Get(p => p.FullName == payment.FullName
            && p.CardNumber == payment.CardNumber
            && p.CustomerId == payment.CustomerId
            && p.CVV==payment.CVV
            && p.Year == payment.Year
            && p.Month == payment.Month);

            if(result != null)
            {
                return new SuccessResult(Messages.PaymentSuccessFul);
            }
            return new ErrorResult(Messages.PaymentFailed);

        }

        public IResult Update(Payment payment)
        {
            _paymentDal.Update(payment);
            return new SuccessResult();
        }
    }
}
