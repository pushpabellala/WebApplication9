using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication9.Models;

namespace WebApplication9.Controllers
{
    public class ProductsController : ApiController
    {
        // GET: api/Products
        static List<Product> _ProductList = null;
        void Initialize()
        {
            _ProductList = new List<Product>()
           {
               new Product() { Id=1, Name="Book" , Quantity=89,Description="good",Supplier="outer"},

               new Product() { Id=2, Name="Pencil" ,Quantity=99,Description="very good",Supplier="outer2"},
           };

        }
        public ProductsController()
        {
            if (_ProductList == null)
            {
                Initialize();
            }
        }

        // GET: api/Products
        public IHttpActionResult Get()
        {
            return Ok(_ProductList);
            //return Request.CreateResponse(HttpStatusCode.OK, _ProductList);

        }

        // GET: api/Products/5
        public IHttpActionResult Get(int id)
        {
            Product Product = _ProductList.FirstOrDefault(x => x.Id == id);
            if (Product == null)
            {
                return NotFound();
                //return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Product not found");
            }
            else
            {
                return Ok(Product);
                //
                //return Request.CreateResponse(HttpStatusCode.Found, Product);
            }


        }



        // POST: api/Products
        public IHttpActionResult Post(Product Product)
        {
            if (Product != null)
            {
                _ProductList.Add(Product);
            }
            return Content(HttpStatusCode.Created, "Record Created");
            // return Request.CreateResponse(HttpStatusCode.Created, "Record inserted");
        }

        // PUT: api/Products/5
        public IHttpActionResult Put(int id, Product objProduct)
        {
            Product Product = _ProductList.Where(x => x.Id == id).FirstOrDefault();
            if (Product == null)
            {
                return NotFound();
                // return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Product not found");
            }
            else
            {
                if (Product != null)
                {
                    foreach (Product temp in _ProductList)
                    {
                        if (temp.Id == id)
                        {
                            temp.Name = objProduct.Name;
                            temp.Quantity = objProduct.Quantity;
                            temp.Description = objProduct.Description;
                            temp.Supplier = objProduct.Supplier;
                        }
                    }

                }
                return Content(HttpStatusCode.OK, "Record Modified");
                // return Request.CreateResponse(HttpStatusCode.OK, "Record modified");
            }
        }

        // DELETE: api/Products/5
        public IHttpActionResult Delete(int? id)
        {
            if (id != null)
            {
                Product Product = _ProductList.FirstOrDefault(x => x.Id == id);
                if (Product == null)
                {
                    return NotFound();
                    // return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Product not found");
                }

                else
                {

                    _ProductList.Remove(Product);
                    return Content(HttpStatusCode.OK, "Record deleted");
                    //  return Request.CreateResponse(HttpStatusCode.OK, "Record Deleted");
                }
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, "Please provide ID");
                //  return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Please provide id"); 
            }
        }
    }
}






