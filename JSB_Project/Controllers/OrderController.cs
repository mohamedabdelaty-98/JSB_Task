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
    public class OrderController : ControllerBase
    {
        private readonly IOrder _Order;
        private readonly IMapper _mapper;
        public OrderController(IOrder _Order,IMapper _mapper)
        {
            this._mapper = _mapper;
            this._Order = _Order;
        }
        [HttpGet("GetOrders")]
        public ActionResult<Result> GetAll()
        {
            List<Order> orders = _Order.GetAll();
            List<DTOOrder> dTOOrders =
               orders.Select(item => _mapper.Map<DTOOrder>(item)).ToList();
            Result result = new Result();
            result.IsSuccess(dTOOrders);
            return result;
        }
        [HttpGet("GetOrderById/{id}")]
        public ActionResult<Result> GetById(string id)
        {
            Order order = _Order.GetById(id);
            DTOOrder dTOOrder = _mapper.Map<DTOOrder>(order);
            Result result = new Result();
            result.IsSuccess(dTOOrder);
            return result;
        }
        [HttpPost("InsertOrder")]
        public ActionResult<Result> Insert(DTOOrder dTOOrder)
        {
            Result result = new Result();
            if (ModelState.IsValid)
            {
                try
                {
                    Order order = _mapper.Map<Order>(dTOOrder);
                    _Order.insert(order);
                    _Order.save();
                    result.IsSuccess(dTOOrder, $"Order created with Id {order.OrderId}");
                }
                catch (Exception ex)
                {
                    result.IsSuccess<Order>(null, FailurMessage: "An error occurred while creating Order.");
                }
            }
            else
            {
                string message = ModelState.Values.SelectMany(v => v.Errors)
                                   .Select(e => e.ErrorMessage).FirstOrDefault();

                result.IsSuccess<Order>(null, FailurMessage: message);
            }
            return result;
        }
        [HttpPut("UpdateOrder")]
        public ActionResult<Result> Update(DTOOrder dTOOrder)
        {
            Result result = new Result();
            if (ModelState.IsValid)
            {
                try
                {
                    Order order = _Order.GetById(dTOOrder.OrderId);
                    if (order != null)
                    {
                        _mapper.Map(dTOOrder, order);
                        _Order.update(order);
                        _Order.save();
                        result.IsSuccess(dTOOrder, SuccessMessage: $"Order with Id {dTOOrder.OrderId} Updated Successfuly");
                    }
                    else
                        result.IsSuccess<Order>(null, FailurMessage: "Order Not Found");
                }
                catch (Exception ex)
                {
                    result.IsSuccess<Order>(null, FailurMessage: "An error occurred while Updating Order.");
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

        [HttpDelete("DeleteOrder/{id}")]
        public ActionResult<Result> Delete(string id)
        {
            Result result = new Result();
            Order order = _Order.GetById(id);
            DTOOrder dTOOrder = _mapper.Map<DTOOrder>(order);
            if (order != null)
            {
                _Order.Delete(id);
                _Order.save();
                result.IsSuccess(dTOOrder, SuccessMessage: $"Order With Id {id} Deleted Successfuly");
            }
            else
                result.IsSuccess<Product>(null);
            return result;
        }
    }
}
