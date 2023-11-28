using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public class Messages
    {
        public static string CarAdded = "Araba eklendi.";
        public static string CarListed = "Arabalar listelendi.";
        public static string CarUpdated = "Araba güncellendi";
        public static string BrandAdded = "Marka eklendi.";
        public static string BrandListed = "Markalar listelendi.";
        public static string BrandUpdated="Marka güncellendi";
        public static string ColorAdded = "Renk eklendi.";
        public static string ColorListed = "Renkler listelendi.";
        public static string ColorUpdated = "Renk güncellendi";
        public static string UserAdded = "Kullanıcı eklendi.";
        public static string UserDeleted = "Kullanıcı silindi.";
        public static string UserUpdated = "Kullanıcı güncellendi.";
        public static string UserListed = "Kullanıcılar listelendi.";
        public static string CustomerAdded = "Müşteri eklendi.";
        public static string CustomerDeleted = "Müşteri silindi.";
        public static string CustomerUpdated = "Müşteri güncellendi.";
        public static string CustomerListed = "Müşteriler listelendi.";
        public static string RentalAdded = "Araba kiralandı.";
        public static string RentalNotAdded = "Araba teslim edilmedi.";
        public static string RentalDeleted = "Araba teslim edildi.";
        public static string RentalUpdated = "Araba kiralama tarihi güncellendi.";
        public static string RentalListed = "Kiralık arabalar listelendi.";
        public static string CarImageAdded = "Araba resmi eklendi.";
        public static string CarImagesListed = "Araba resimleri listelendi.";
        public static string CarImageLimitExceded = "Bir arabanın en fazla 5 resmi olabilir.";
        public static string AuthorizationDenied="Yetkiniz yok";
        public static string UserRegistered="Kayıt başarılı";
        public static string UserNotFound="Kullanıcı bulunamadı";
        public static string PasswordError="Parola hatası";
        public static string SuccessfulLogin="Başarılı giriş";
        public static string UserAlreadyExists="Kullanıcı mevcut";
        public static string AccessTokenCreated="Token oluşturuldu";
        public static string RentError="Kiralama işlemi başarısız";
        public static string CarAlreadyRented="Bu araba zaten kiralanmış";
        public static string CarRentalAdded="Araba başarıyla kiralandı";
        public static string PaymentFailed="Ödeme başarısız";
        public static string PaymentSuccessFul="Ödeme başarılı";
        public static string BrandCanNotEmpty="Marka adı boş bırakılamaz.";
        public static string CustomerFindexScoreIsZero="Müşterinin findeks puanı 0";
        public static string CustomerFindexScoreIsNotEnough="Müşterinin findeks puanı yeterli değil.";
        public static string RentalInavalid="Kiralama başarısız";
        public static string RentalSuccess="Araç kiralanabilir.";
        public static string CarIsReturned="Araba teslim edildi.";
        public static string Success = "İşlem başarılı";
        public static string CardSaved="Kart kaydedildi!";
        public static string CardUpdated="Kart bilgileri güncellendi!";
        public static string CardsListed="Kart bilgileri listelendi.";
        public static string CardNotFound="Kart bulunamadı.";
        public static string CardNotValid="Kart geçersiz";
        public static string CardDeleted="Kart silindi";
    }
}
