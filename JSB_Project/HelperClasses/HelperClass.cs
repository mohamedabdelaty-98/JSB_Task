using BussinessLayer.DTO;

namespace JSB_Project.HelperClasses
{
    public static class HelperClass
    {
        public static Result IsSuccess<T>(this Result result, T Data,
            string SuccessMessage = "Operation successful", string FailurMessage = "No data found", bool isPass = true)
        {
            isPass = Data is IEnumerable<object> list ? list.Any() : Data != null;
            result.IsPass = isPass;
            result.meesage = isPass ? SuccessMessage : FailurMessage;
            result.Data = Data;
            return result;
        }
    }
}
