using System.Collections.Generic;

public class EntityManagement<T>
{
    private List<T> entities = new List<T>();

    public void AddEntity(T entity)
    {
        entities.Add(entity);
    }

    public void RemoveEntity(T entity)
    {
        entities.Remove(entity);
    }

    public IEnumerable<T> GetAllEntities()
    {
        return entities;
    }

    // Outros métodos CRUD e lógica adicional
}