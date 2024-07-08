using AutoMapper;
using BussinessLayer.DTO;
using DataAccessLayer.Models;
using DataAccessLayer.Reposatories;
using JSB_Project.HelperClasses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JSB_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProduct _Product;
        private readonly IMapper _mapper;
        public ProductController(IProduct _Product, IMapper _mapper)
        {
            this._Product = _Product;
            this._mapper = _mapper;
        }
        [HttpGet("GetProducts")]
        public ActionResult<Result> GetAll()
        {
            List<Product> products = _Product.GetAll();
            List<DTOProduct> dTOProducts =
               products.Select(item => _mapper.Map<DTOProduct>(item)).ToList();
            Result result = new Result();
            result.IsSuccess(dTOProducts);
            return result;

        }
        [HttpGet("GetProductById/{id}")]
        public ActionResult<Result> GetById(int id)
        {
            Product product = _Product.GetById(id);
            DTOProduct dTOProduct = _mapper.Map<DTOProduct>(product);
            Result result = new Result();
            result.IsSuccess(dTOProduct);
            return result;

        }
        [HttpPost("InsertProduct")]
        public ActionResult<Result> Insert(DTOProduct dTOProduct)
        {
            Result result = new Result();
            if (ModelState.IsValid)
            {
                try
                {
                    Product product = _mapper.Map<Product>(dTOProduct);
                    _Product.insert(product);
                    _Product.save();
                    result.IsSuccess(dTOProduct, $"Product created with Id {product.Id}");
                }
                catch (Exception ex)
                {
                    result.IsSuccess<Product>(null, FailurMessage: "An error occurred while creating the Product.");
                }
            }
            else
            {
                string message = ModelState.Values.SelectMany(v => v.Errors)
                                   .Select(e => e.ErrorMessage).FirstOrDefault();

                result.IsSuccess<Product>(null, FailurMessage: message);
            }
            return result;
        }
        [HttpPut("UpdateProduct")]
        public ActionResult<Result> Update(DTOProduct dTOProduct)
        {
            Result result = new Result();
            if (ModelState.IsValid)
            {
                try
                {
                    Product product = _Product.GetById(dTOProduct.Id);
                    if (product != null)
                    {
                        _mapper.Map(dTOProduct, product);
                        _Product.update(product);
                        _Product.save();
                        result.IsSuccess(dTOProduct, SuccessMessage: $"Product with Id {dTOProduct.Id} Updated Successfuly");
                    }
                    else
                        result.IsSuccess<Product>(null, FailurMessage: "Product Not Found");
                }
                catch (Exception ex)
                {
                    result.IsSuccess<Product>(null, FailurMessage: "An error occurred while Updating the Product.");
                }
            }
            else
            {
                string message = ModelState.Values.SelectMany(v => v.Errors)
                                   .Select(e => e.ErrorMessage).FirstOrDefault();

                result.IsSuccess<Product>(null, FailurMessage: message);
            }
            return result;
        }
        [HttpDelete("DeleteProduct/{id}")]
        public ActionResult<Result> Delete(int id)
        {
            Result result = new Result();
            Product product = _Product.GetById(id);
            DTOProduct dTOProduct=_mapper.Map<DTOProduct>(product);
            if (product != null)
            {
                _Product.Delete(id);
                _Product.save();
                result.IsSuccess(dTOProduct, SuccessMessage: $"Product With Id {id} Deleted Successfuly");
            }
            else
                result.IsSuccess<Product>(null);
            return result;
        }
    }
}
