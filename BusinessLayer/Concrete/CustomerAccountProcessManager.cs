using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete;

public class CustomerAccountProcessManager : ICustomerAccountProcessService
{
    private readonly ICustomerAccountProcessDal _customerAccountProcessDal;
    public CustomerAccountProcessManager(ICustomerAccountProcessDal customerAccountProcessDal)
    {
        _customerAccountProcessDal = customerAccountProcessDal;
    }

    public void TInsert(CustomerAccountProcess t)
    {
        _customerAccountProcessDal.Insert(t);
    }

    public void TDelete(CustomerAccountProcess t)
    {
        _customerAccountProcessDal.Delete(t);
    }

    public void TUpdate(CustomerAccountProcess t)
    {
        _customerAccountProcessDal.Update(t);
    }

    public CustomerAccountProcess TGetById(int id)
    {
        return _customerAccountProcessDal.GetById(id);
    }

    public List<CustomerAccountProcess> TGetList()
    {
        return _customerAccountProcessDal.GetList();
    }
}