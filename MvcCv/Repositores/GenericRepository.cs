using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using MvcCv.Models.Entity;

namespace MvcCv.Repositores
{
    public class GenericRepository<T> where T : class, new()//T-->Sınıflarımızı Alacak ve T Bir Sınıf Olacak.
    {
        DbCvEntities db = new DbCvEntities();

        //Bu Yapı Sayesinde Crud İşlemlerini Çok Daha Hızlı Bir Şekilde Yaıyoruz.


        public List<T>List()//Listeleme
        {
            return db.Set<T>().ToList();
        }
        public void TAdd(T p)//Ekleme
        {
            db.Set<T>().Add(p);
            db.SaveChanges();
        }
        public void TDelete(T p)//Silme
        {
            db.Set<T>().Remove(p);
            db.SaveChanges();
        }
        public T Find(Expression<Func<T,bool>>Where)//Id Bulmak İçin Find Methodu
        {
            return db.Set<T>().FirstOrDefault(Where);
        }
        public T TGet(int id)
        {
            return db.Set<T>().Find(id);
        }
        public void TUpdate(T p)//Güncelleme
        {
            db.SaveChanges();
        }



    }
}