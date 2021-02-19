using Microsoft.AspNetCore.Identity;
using Project.ENTITIES.CoreInterfaces;
using Project.ENTITIES.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.DAL.DALModel
{
    //AppUser , IdentityUser'dan miras alarak bu sınıfın özelliklerini icine almak istiyorsa artık nerede IdentityUser kullanacak isek oraya AppUser class'ını yazmalıyız...
    public class AppUser:IdentityUser,IEntity
    {
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DataStatus? Status { get; set; }
    }
}
