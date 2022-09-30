namespace ContosoPizza.Repository.Contracts
{
    public interface IManageFile<T>
    {
        bool Add(T item, string path);
        T Get (int id, string path);
        List<T> GetAll(string path);
    }
}
