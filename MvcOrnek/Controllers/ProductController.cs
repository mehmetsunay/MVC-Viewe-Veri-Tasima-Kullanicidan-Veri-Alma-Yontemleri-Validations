using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MvcOrnek.Models;
using MvcOrnek.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcOrnek.Controllers
{


    //[NonController] bu ne diye bkma aşagıda 118.satırda yazıyor : ))

    public class ProductController : Controller
    {
        //ACTİON TÜRLERİ DÖNÜŞ TİPLERİ
        /*
         Bildiğimiz üzere client ten gelen requesti controller karşılayıp uygun
         actiona yönlendiriyordu...
         Actionda ihtiyaca göre operasyonu yönetiyordu
         İşte bu durumlarda action içindeki döndürülen dönen kısımların farklı türleri mevcut

         */


        #region ViewResult
        //public ViewResult GetProducts()
        //{
        //    //Response olarak bir view dosyasını(cshtml) render yapmamı sağlar.
        //    ViewResult result = View();
        //    return result;

        //}

        #endregion

        #region PartialViewResult

        //public PartialViewResult GetProducts()
        //{
        ////Response olarak bir view dosyasını(cshtml) render yapmamı sağlar.
        ////Diğeri bir bütün olarak web sayfasını ele alırken bunda belli bir kısım üzerinde işl.yap.
        //  PartialViewResult result = PartialView();
        //  return result;

        //}

        #endregion

        #region JsonResult

        //public JsonResult GetProducts()
        //{   

        //    //Üretilen Datayı JSON Türüne Dönüştürüp Döndüren Bir Action Tipidir
        //    JsonResult result = Json(new Product
        //    {
        //        Id=3,
        //        ProductName ="SPHONE",
        //        ProductPrice=130

        //    });

        //    return result;
        //}



        #endregion

        #region EmptyResult
        //public EmptyResult GetProducts()
        //{

        //    return new EmptyResult();
        //}


        #endregion

        #region ContentResult
        //public ContentResult GetProducts()
        //{

        //    ContentResult result = Content("HAFTAYA BERİVANLARIN DÜĞÜNÜNE HERKES DAVETLİDİR");

        //    return result;
        //}
        #endregion

        #region ActionResult
        //Gelen isteğe göre geriye döndürülecek action türleri farklılık gösterdiğinde kullanılır

        //public ActionResult GetProducts()
        //{
        //    if (true)
        //    {
        //        return Json(new object());

        //    }
        //    else if(false)
        //    {
        //        return Content("BEN BİR CONTENTİMMMM");

        //    }


        //}

        #endregion



        /*NONACTİON - NONCONTROLLER KAVRAMLARI*/

        /*
         Kontroller iş yapan değil işi yönetenlerdir
         Actionlarda onların yardımcıları gibi çalışırlar
         Onlarda iş yapmaz yönetir(Servisleri çağırır yönlendirmeler yapar vb)
         

         */

        #region ÖRNEK
        //public IActionResult Index()
        //{
        //    Y();
        //    return View();

        //}

        ////NOT:KONTROLRLAR SINIFIN İÇERİSİNDEKİ METOD TÜRÜ NE OLURSA OLSUN ACTİONDIR
        ////Yani dışardan request(istek) karşılarlar
        //[NonAction]
        //public void Y()
        //{



        //}

        #endregion


        /*VİEWE VERİ TAŞIMA - VERİ YAPILANMASI*/

        /*
         Css html jscript gibi yapılar evrenseldir 
         Ancak cshtml dosyaları sadece bu teknoliye özeldir ve kullanıcı bunu html olarak görür
         
         */

        public IActionResult Index()

        {
            var products = new List<Product>
            {

                new Product {  Id=1,ProductName="Iphone" ,ProductPrice=400  },
                 new Product {  Id=2,ProductName="Samsung" ,ProductPrice=300  },
                  new Product {  Id=4,ProductName="Vestel" ,ProductPrice=250  }

              };

            #region MODEL ESASLI VERİ GÖNDERİMİ

            // return View(products);

            #endregion

            #region VİEWBAG
            ////Taşınacak olan veriyi dinamik bir şekilde taşımamızı sağlayan kontroldür(değişkenle)
            ViewBag.products = products;

            #endregion

            #region VİEWDATA
            //Bu kontrolde viewbag de olduğu gibi veri taşımamızı sağlar ama boxinge tabı tutar
            ViewData["products"] = products;

            #endregion

            #region TEMPDATA
            //Buda bir çeşit veri taşıma kontrolüdür...
            TempData["products"] = products;

            #endregion


            return View();


        }



        /*VİEWE BİRDEN FAZLA VERİ GÖNDERİMİ*/

        /* public IActionResult GetProducts()
         {
             Product product = new Product()
             {
                 Id=5,
                 ProductName="Alcatel",
                 ProductPrice=200

             };

             Customer customer = new Customer()
             {
                 Id = 5,
                 Name = "mehmet",
                 Surname="sunay"


             };

             CustomerProduct customerProduct = new CustomerProduct
             {

                 Customer=customer,
                 Product= product


             };


             return View(customerProduct);*/

        public IActionResult GetProducts()
        {

            //Viewbag Bildiğiiniz bizim veri taşıma metodlarımdan birisi mesajımı dinamık bir nesneyle gonderdım
            ViewBag.Mesaj = "Not Found Product";
            //Customerdan türettiğim nesnemi model bazlı göndermiş oldum 
            Customer c = new Customer
            {
                Name = "Ömer"


            };

            return View(c);

        }

        public IActionResult CreateCustomer()
        {
            return View();


        }


        //View(cshtml)üzerinden oluşturduğumuz formumuzdan
        //post ettiğimiz verileri controller tarafında yıne post att.
        //belırledıgımız method içerisinde yakaladık ve breakpoıntle kontrol ettık.

        [HttpPost]
        public IActionResult CreateCustomer(string txtName,string txtSurname)
        {
           
            return View();
         
        }

        //Modeldeki Sınıfımı kullanarak post işlemini gerçekleştirdim
        //Ama bunu yaparken viewle bagşantılı olan default metodumuda eklemeyı unutmamalıyım.
        public IActionResult MusteriOlustur()
        {
            return View();


        }
        //metoduma post özelliğimi ekleyebilmem için aşağıdaki atr.kullan....
        [HttpPost]
        public IActionResult MusteriOlustur(Customer customer)
        {
            return View();


        }


        public IActionResult MusteriVeliNimettir()
        {
            return View();


        }

        [HttpPost]
        public IActionResult MusteriVeliNimettir(IFormCollection deger)

        {

            var deg1 = deger["txtVal1"].ToString();
            var deg2 = deger["txtVal2"].ToString();


            return View();


        }

       
        public IActionResult TakeData()
        {
            var queryString = Request.QueryString;

            var c = Request.Query["c"].ToString();
            var m = Request.Query["m"].ToString();

           
            return View();


        }


        public JsonResult GelBakalim()
        {
            JsonResult result = Json(new Customer 
            {
                Name = "Mehmet",
                Surname="Sunay"
               


            });

            return result;



        }


        public IActionResult UrunDogrulama()
        {
        

          return View();

        }

        [HttpPost]
        public IActionResult UrunDogrulama(Customer model)
        {

            if(!ModelState.IsValid)
            {
                //kullanıcı işlemleri
                //log işlemleri
                //Veri taşıma vb


                ViewBag.HataMesaj = ModelState.Values.FirstOrDefault(x => x.ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid).Errors[0].ErrorMessage;




                return View();

            }

            

            return View();

        }





    }






    }

