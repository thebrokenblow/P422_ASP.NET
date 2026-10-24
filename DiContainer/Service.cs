namespace DiContainer;

public class Service
{
    private Repository _repository;
    private Validation _validation;

    public Service(Repository repository, Validation validation)
    {
        _repository = repository;
        _validation = validation;
    }
}
